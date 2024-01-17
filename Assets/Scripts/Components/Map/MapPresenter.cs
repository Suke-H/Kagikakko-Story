using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVRP.Model;
using MVRP.View;

namespace MVRP.Presenter
{
    public class MapPresenter : MonoBehaviour
    {
        [SerializeField] private MapModel mapModel;
        [SerializeField] private MapView mapView;
        public WorldType currentWorldType
        {
            get { return mapModel.currentWorldType; }
        }
        public List<List<WordPresenter>> bookWordMap
        {
            get { return mapModel.bookWordMap; }
        }
        public List<List<ObjectPresenter>> storyObjectMap
        {
            get { return mapModel.storyObjectMap; }
        }

        public void Initialize(List<List<ObjectType>> bookMap, List<List<ObjectType>> storyMap)
        {
            mapModel.Initialize(bookMap, storyMap);
            mapView.Initialize(bookMap, storyMap);
        }
        public void PrintObjectMap()
        {
            CSVReader.PrintObjectMap(storyObjectMap);
        }
        public void PrintWordMap()
        {
            CSVReader.PrintWordMap(bookWordMap);
        }
        public void SwitchWorld(WorldType nextWorldType)
        {
            mapModel.SwitchWorld(nextWorldType);
        }
    }
}


