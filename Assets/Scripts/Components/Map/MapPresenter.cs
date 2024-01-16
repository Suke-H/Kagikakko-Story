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

        public List<List<ObjectType>> currentMap
        {
            get { return mapModel.GetCurrentMap(); }
        }

        public WorldType currentWorldType
        {
            get { return mapModel.currentWorldType; }
        }

        public void Initialize(List<List<ObjectType>> bookMap, List<List<ObjectType>> storyMap)
        {
            mapModel.Initialize(bookMap, storyMap);
            mapView.Initialize(bookMap, storyMap);
        }

        public void PrintCurrentMap()
        {
            CSVReader.Print(currentWorldType.ToString(), currentMap);
        }

        public void SwitchWorld(WorldType nextWorldType)
        {
            mapModel.SwitchWorld(nextWorldType);
        }
    }
}


