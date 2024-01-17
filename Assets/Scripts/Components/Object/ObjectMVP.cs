using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MVRP.Model;
using MVRP.View;
using MVRP.Presenter;

// namespace MVPR.MVP
// {
    public class ObjectMVP : MonoBehaviour
    {
        [SerializeField] private ObjectPresenter objectPresenter;

        public ObjectPresenter GetObjectPresenter()
        {
            return objectPresenter;
        }
    }
// }

