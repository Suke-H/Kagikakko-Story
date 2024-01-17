using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVRP.Model;
using MVRP.View;

namespace MVRP.Presenter
{
    public class ObjectPresenter : MonoBehaviour
    {
        [SerializeField] private ObjectModel objectModel;
        [SerializeField] private ObjectView objectView;

        public ObjectState objectState
        {
            get { return objectModel.objectState.Clone(); }
        }

        public void Initialize(ObjectType objectType, int x, int y)
        {
            // モデルの初期化
            objectModel.Initialize(objectType, x, y);
            // ビューの初期化
            objectView.Initialize(objectType);
        }
    }

}
