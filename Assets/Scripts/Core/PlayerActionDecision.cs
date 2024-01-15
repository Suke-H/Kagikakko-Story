using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVRP.Presenter;

public class PlayerActionDecision : MonoBehaviour
{
    [SerializeField] private PlayerPresenter playerPresenter;
    [SerializeField] private MapPresenter mapPresenter;

    public void DecidePlayerAction(UserInput userInput)
    {
        Vector2Int nextPosition = playerPresenter.GetPlayerState().position;

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

        if (!mapPresenter.CanMove(nextPosition))
        {
            Debug.Log("Can't move");
            return;
        }

        playerPresenter.Move(nextPosition);
    }
}
