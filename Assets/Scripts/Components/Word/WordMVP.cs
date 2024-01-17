using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MVRP.Model;
using MVRP.View;
using MVRP.Presenter;

// namespace MVPR.MVP
// {
    public class WordMVP : MonoBehaviour
    {
        [SerializeField] private WordPresenter wordPresenter;

        public WordPresenter GetWordPresenter()
        {
            return wordPresenter;
        }
    }
// }

