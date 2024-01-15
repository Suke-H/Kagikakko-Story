using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVRP.Model
{
    public class MapModel : MonoBehaviour
    {
        private List<List<ObjectType>> bookMap;
        private List<List<ObjectType>> storyMap;

        public void Initialize(List<List<ObjectType>> bookMap, List<List<ObjectType>> storyMap)
        {
            this.bookMap = new List<List<ObjectType>>(bookMap);
            this.storyMap = new List<List<ObjectType>>(storyMap);

            CSVReader.Print("book", bookMap);
            // CSVReader.Print("story", storyMap);
        }

        public bool CanMove(Vector2Int nextPosition)
        {
            // マップの範囲外には移動できない
            if (nextPosition.x < 0 || nextPosition.x >= bookMap[0].Count ||
                nextPosition.y < 0 || nextPosition.y >= bookMap.Count)
            {
                return false;
            }

            // マップ内にオブジェクトがあれば移動できない
            if (bookMap[nextPosition.y][nextPosition.x] != ObjectType.None)
            {
                return false;
            }

            return true;
        }

    }
}

