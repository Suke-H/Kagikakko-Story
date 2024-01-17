using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVRP.Model;
using MVRP.View;

namespace MVRP.Presenter
{
    public class WordPresenter : MonoBehaviour
    {
        [SerializeField] private WordModel wordModel;
        [SerializeField] private WordView wordView;

        public WordState wordState
        {
            get { return wordModel.wordState.Clone(); }
        }

        public void Initialize(ObjectType objectType, int x, int y)
        {
            // モデルの初期化
            wordModel.Initialize(objectType, x, y);
            // ビューの初期化
            wordView.Initialize(objectType);
        }
    }

}
