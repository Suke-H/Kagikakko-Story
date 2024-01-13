using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MVRP.Model;
using MVRP.View;

namespace MVRP.Presenter
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

        public void Move(UserInput userInput)
        {
            // モデルの移動
            playerModel.Move(userInput);

            // ビューの移動
            playerView.Move(userInput);
        }
    }

}


