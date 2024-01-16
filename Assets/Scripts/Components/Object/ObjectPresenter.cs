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

        public void Initialize(ObjectType objectType)
        {
            // モデルの初期化
            objectModel.Initialize(objectType);

            // ビューの初期化
            objectView.Initialize(objectType);
        }

    }

}
