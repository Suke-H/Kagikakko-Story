using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MVRP.Presenter;

public class ActionDecision : MonoBehaviour
{
    [SerializeField] private BookWorldDecision bookWorldDecision;
    [SerializeField] private StoryWorldDecision storyWorldDecision;
    [SerializeField] private ActionSender actionSender;
    [SerializeField] private PlayerPresenter playerPresenter;
    [SerializeField] private MapPresenter mapPresenter;

    public void DecideAction(UserInput userInput)
    {
        // 現在の情報
        Vector2Int currentPosition = playerPresenter.GetPlayerState().position;
        WorldType currentWorldType = mapPresenter.GetCurrentWorldType();
        var currentMap = mapPresenter.GetCurrentMap();

        /* 行動 */
        Actions actions = new Actions(currentPosition, currentWorldType);

        // 次の位置
        Vector2Int nextPosition = CalcNextPosition(currentPosition, userInput);

        // マップの範囲外には移動できない
        if (IsInsideMapArea(nextPosition))
        {
            // 本の世界
            if (mapPresenter.GetCurrentWorldType() == WorldType.Book)
            {
                actions = bookWorldDecision.DecideAction(currentMap, nextPosition);
            }
            // 物語の世界
            else
            {
                actions = storyWorldDecision.DecideAction(currentMap, currentPosition, nextPosition);
            }
        }
        // 行動を送信
        actionSender.SendActionToPresenters(actions);

        // デバッグ用
        mapPresenter.PrintCurrentMap();
        playerPresenter.PrintPlayerState();
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
