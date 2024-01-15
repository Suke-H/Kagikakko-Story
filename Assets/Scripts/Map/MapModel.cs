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

        public List<List<ObjectType>> GetCurrentMap()
        {
            CSVReader.Print(currentWorldType.ToString(), worldMapDict[currentWorldType]); // Debug
            return worldMapDict[currentWorldType];
        }

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

