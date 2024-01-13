using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVPR.Model;
using MVPR.View;

namespace MVPR.Presenter
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
    }
}


