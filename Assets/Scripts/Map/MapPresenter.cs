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


        public void Initialize(List<List<ObjectType>> bookMap, List<List<ObjectType>> storyMap)
        {
            mapModel.Initialize(bookMap, storyMap);
            mapView.Initialize(bookMap, storyMap);
        }

        public List<List<ObjectType>> GetCurrentMap()
        {
            return mapModel.GetCurrentMap();
        }

        public WorldType GetCurrentWorldType()
        {
            return mapModel.GetCurrentWorldType();
        }

        public void PrintCurrentMap()
        {
            CSVReader.Print(GetCurrentWorldType().ToString(), GetCurrentMap());
        }

        public void SwitchWorld(WorldType nextWorldType)
        {
            mapModel.SwitchWorld(nextWorldType);
        }
    }
}


