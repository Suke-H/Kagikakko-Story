using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using MVRP.Presenter;

namespace MVRP.Model
{
    public class MapModel : MonoBehaviour
    {
        [SerializeField] private WordMVP bookWordPrefab;
        [SerializeField] private ObjectMVP storyObjectPrefab;

        public List<List<WordPresenter>> bookWordMap { get; private set; }
        public List<List<ObjectPresenter>> storyObjectMap { get; private set; }

        public WorldType currentWorldType  { get; private set; }

        public void Initialize(List<List<ObjectType>> bookMap, List<List<ObjectType>> storyMap)
        {
            // オブジェクトマップ作成
            bookWordMap = bookMap.Select((row, y) => 
                row.Select((item, x) => ConvertToWord(item, x, y)).ToList()
            ).ToList();
            storyObjectMap = storyMap.Select((row, y) => 
                row.Select((item, x) => ConvertToObject(item, x, y)).ToList()
            ).ToList();

            // 現在の世界を本の世界に設定
            currentWorldType = WorldType.Book;
        }

        // ObjectTypeからWordPresenterへの変換
        private WordPresenter ConvertToWord(ObjectType objectType, int x, int y)
        {
            // Noneの場合は何もしない
            if (objectType == ObjectType.None)
            {
                return null;
            }
            // インスタンス作成
            WordMVP wordMVP = Instantiate(bookWordPrefab);
            wordMVP.transform.SetParent(transform); // 親設定
            WordPresenter wordPresenter = wordMVP.GetWordPresenter();
            // 初期化
            wordPresenter.Initialize(objectType, x, y);

            return wordPresenter;
        }

        // ObjectTypeからObjectPresenterへの変換
        private ObjectPresenter ConvertToObject(ObjectType objectType, int x, int y) 
        {
            // Noneの場合は何もしない
            if (objectType == ObjectType.None) {
                return null;
            }
            // インスタンス作成
            ObjectMVP objectMVP = Instantiate(storyObjectPrefab); 
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
        // public void MoveObject(Vector2Int currentPosition, Vector2Int nextPosition)
        // {
        //     var currentMap = worldMapDict[currentWorldType];
        //     var currentObject = currentMap[currentPosition.y][currentPosition.x];

        //     // 現在のマップからオブジェクトを削除
        //     currentMap[currentPosition.y][currentPosition.x] = ObjectType.None;
        //     // 次のマップにオブジェクトを追加
        //     currentMap[nextPosition.y][nextPosition.x] = currentObject;
        // }

    }
}

