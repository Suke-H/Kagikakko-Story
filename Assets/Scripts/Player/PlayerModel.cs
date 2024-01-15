using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVRP.Presenter;

namespace MVRP.Model
{
    public class PlayerModel : MonoBehaviour
    {
        public PlayerState playerState { get; private set; }

        [SerializeField] private MapPresenter mapPresenter;
        
        public void Initialize(Vector2Int position)
        {
            playerState = new PlayerState(position, false, WorldType.Book, ObjectType.BookPlayer);
            playerState.Print();
        }

        public void Move(Vector2Int nextPosition)
        {
            playerState.position = nextPosition;
            playerState.Print();
        }

    }

}
