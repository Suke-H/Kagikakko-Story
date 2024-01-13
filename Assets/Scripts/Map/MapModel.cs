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
            CSVReader.Print("story", storyMap);
        }

    }
}

