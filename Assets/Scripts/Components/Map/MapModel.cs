using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using MVRP.Presenter;

namespace MVRP.Model
{
    public class MapModel : MonoBehaviour
    {
        [SerializeField] private ObjectMVP bookObjectPrefab;

        private List<List<ObjectType>> bookMap;
        private List<List<ObjectType>> storyMap;

        private List<List<ObjectPresenter>> bookObjectMap;
        private List<List<ObjectPresenter>> storyObjectMap;

        public WorldType currentWorldType  { get; private set; }
        private Dictionary<WorldType, List<List<ObjectType>>> worldMapDict = new Dictionary<WorldType, List<List<ObjectType>>>();

        public List<List<ObjectType>> GetCurrentMap()
        {
            return worldMapDict[currentWorldType];
        }

        public void Initialize(List<List<ObjectType>> bookMap, List<List<ObjectType>> storyMap)
        {
            // マップの初期化
            this.bookMap = new List<List<ObjectType>>(bookMap);
            this.storyMap = new List<List<ObjectType>>(storyMap);

            // オブジェクトマップ作成
            bookObjectMap = bookMap.Select((row, y) => 
                row.Select((item, x) => ConvertToObject(item, x, y)).ToList()
            ).ToList();
            // storyObjectMap = storyMap.Select(
            //     row => Enumerable.Repeat(None, row.Count).ToList()
            // ).ToList();

            // 現在の世界を本の世界に設定
            currentWorldType = WorldType.Book;
            // 世界ごとのマップを辞書に登録
            worldMapDict.Add(WorldType.Book, this.bookMap);
            worldMapDict.Add(WorldType.Story, this.storyMap);
        }

        // ObjectTypeからObjectPresenterへの変換
        private ObjectPresenter ConvertToObject(ObjectType objectType, int x, int y) {
            // Noneの場合は何もしない
            if (objectType == ObjectType.None) {
                return null;
            }

            // インスタンス作成
            ObjectMVP objectMVP = Instantiate(bookObjectPrefab); 
            objectMVP.transform.SetParent(transform); // 親設定
            ObjectPresenter objectPresenter = objectMVP.GetObjectPresenter();
            
            // 初期化
            objectPresenter.Initialize(objectType, x, y);

            return objectPresenter;
        }   

        public bool SwitchWorld(WorldType nextWorldType)
        {
            // 既に同じ世界にいる場合は切り替えない
            if (currentWorldType == nextWorldType)
            {
                return false;
            }

            // 世界を切り替える
            currentWorldType = nextWorldType;
            return true;
        }
        public void MoveObject(Vector2Int currentPosition, Vector2Int nextPosition)
        {
            var currentMap = worldMapDict[currentWorldType];
            var currentObject = currentMap[currentPosition.y][currentPosition.x];

            // 現在のマップからオブジェクトを削除
            currentMap[currentPosition.y][currentPosition.x] = ObjectType.None;
            // 次のマップにオブジェクトを追加
            currentMap[nextPosition.y][nextPosition.x] = currentObject;
        }

    }
}

