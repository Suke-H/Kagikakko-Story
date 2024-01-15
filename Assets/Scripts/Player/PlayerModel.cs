using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVRP.Presenter;

namespace MVRP.Model
{
    public class PlayerModel : MonoBehaviour
    {
        private PlayerState playerState;

        [SerializeField] private MapPresenter mapPresenter;
        
        public void Initialize(Vector2Int position)
        {
            playerState = new PlayerState(position, false, WorldType.Book, ObjectType.BookPlayer);
            playerState.Print();
        }

        public bool CanMove(Vector2Int nextPosition)
        {
            return mapPresenter.CanMove(nextPosition);
        }

        public void Move(UserInput userInput)
        {
            Vector2Int nextPosition = playerState.position;

            switch (userInput)
            {
                case UserInput.Up:
                    nextPosition.y -= 1;
                    break;
                case UserInput.Down:
                    nextPosition.y += 1;
                    break;
                case UserInput.Left:
                    nextPosition.x -= 1;
                    break;
                case UserInput.Right:
                    nextPosition.x += 1;
                    break;
                default:
                    break;
            }

            if (!CanMove(nextPosition))
            {
                Debug.Log("Can't move");
                return;
            }

            playerState.position = nextPosition;
            playerState.Print();
        }


    }

}
