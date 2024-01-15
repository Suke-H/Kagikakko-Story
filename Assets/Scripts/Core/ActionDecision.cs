using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MVRP.Presenter;

public class ActionDecision : MonoBehaviour
{
    
    [SerializeField] private ActionSender actionSender;
    [SerializeField] private PlayerPresenter playerPresenter;
    [SerializeField] private MapPresenter mapPresenter;

    public void DecideAction(UserInput userInput)
    {
        // プレイヤーの次の位置を計算する
        Vector2Int currentPosition = playerPresenter.GetPlayerState().position;
        Vector2Int nextPosition = CalcNextPosition(currentPosition, userInput);

        // 移動場所を決定させる
        Vector2Int determinedPosition;
        if (IsInsideMapArea(nextPosition))
        {
            determinedPosition = nextPosition;
        }
        else
        {
            determinedPosition = currentPosition;
        }

        // 行動の保存
        Actions actions = new Actions(determinedPosition, WorldType.Book);

        // 行動を送信
        actionSender.SendActionToPresenters(actions);
    }

    public Vector2Int CalcNextPosition(Vector2Int currentPosition, UserInput userInput)
    {
        Vector2Int nextPosition = currentPosition;

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

        return nextPosition;
    }

    public bool IsInsideMapArea(Vector2Int nextPosition)
    {
        // 現在の世界のマップを取得
        var currentMap = mapPresenter.GetCurrentMap();

        // マップの範囲外には移動できない
        if (nextPosition.x < 0 || nextPosition.x >= currentMap[0].Count ||
            nextPosition.y < 0 || nextPosition.y >= currentMap.Count)
        {
            return false;
        }

        return true;
    }
}
