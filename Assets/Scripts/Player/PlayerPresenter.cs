using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MVPR.Model;
using MVPR.View;

namespace MVPR.Presenter
{
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private PlayerView playerView;

        public void Initialize(Vector2Int initPosition)
        {
            // モデルの初期化
            playerModel.Initialize(initPosition);

            // ビューの初期化
            playerView.Initialize(initPosition);
        }
    }

}


