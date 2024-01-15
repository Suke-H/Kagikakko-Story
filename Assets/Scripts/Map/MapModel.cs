using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVRP.Model
{
    public class MapModel : MonoBehaviour
    {
        private List<List<ObjectType>> bookMap;
        private List<List<ObjectType>> storyMap;
        
        private WorldType currentWorldType;
        private Dictionary<WorldType, List<List<ObjectType>>> worldMapDict = new Dictionary<WorldType, List<List<ObjectType>>>();


        public void Initialize(List<List<ObjectType>> bookMap, List<List<ObjectType>> storyMap)
        {
            // マップの初期化
            this.bookMap = new List<List<ObjectType>>(bookMap);
            this.storyMap = new List<List<ObjectType>>(storyMap);
            // 現在の世界を本の世界に設定
            currentWorldType = WorldType.Book;
            // 世界ごとのマップを辞書に登録
            worldMapDict.Add(WorldType.Book, this.bookMap);
            worldMapDict.Add(WorldType.Story, this.storyMap);

        }

        public bool CanMove(Vector2Int nextPosition)
        {
            // 現在の世界のマップを取得
            var currentMap = worldMapDict[currentWorldType];
            CSVReader.Print(currentWorldType.ToString(), currentMap); // Debug

            // マップの範囲外には移動できない
            if (nextPosition.x < 0 || nextPosition.x >= currentMap[0].Count ||
                nextPosition.y < 0 || nextPosition.y >= currentMap.Count)
            {
                return false;
            }

            // マップ内にオブジェクトがある場合

            // 本の世界
            if (currentWorldType == WorldType.Book)
            {
                // オブジェクト（=「」付き文字）があれば、世界を切替え、そのオブジェクトに成り変わる。
                if (currentMap[nextPosition.y][nextPosition.x] != ObjectType.None)
                {
                    return false;
                }
            }

            // 物語の世界
            else
            {
                // オブジェクトがあれば、移動できない。
                if (currentMap[nextPosition.y][nextPosition.x] != ObjectType.None)
                {
                    return false;
                }
            }

            return true;
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

    }
}

