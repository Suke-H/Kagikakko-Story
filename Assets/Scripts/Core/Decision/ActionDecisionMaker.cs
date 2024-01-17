using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MVRP.Presenter;

public class ActionDecisionMaker : MonoBehaviour
{
    [SerializeField] private MoveDecision moveDecision;
    [SerializeField] private QuitDecision quitDecision;

    [SerializeField] private ActionSender actionSender;
    [SerializeField] private PlayerPresenter playerPresenter;
    [SerializeField] private MapPresenter mapPresenter;

    public void DecideAction(UserInput userInput)
    {
        /* 現在の情報 */
        Vector2Int currentPosition = playerPresenter.playerState.position;
        WorldType currentWorldType = mapPresenter.currentWorldType;

        var bookObjectMap = mapPresenter.bookWordMap;
        var storyWordMap = mapPresenter.storyObjectMap;

        // 次の位置を計算
        Vector2Int nextPosition = CalcNextPosition(currentPosition, userInput);

        Actions actions = new Actions(currentPosition, currentWorldType);

        /* ユーザー入力による分岐 */
        if (userInput == UserInput.None)
        {
            return;
        }
        else if (userInput == UserInput.Quit)
        {
            actions = quitDecision.DecideToQuit(currentPosition, currentWorldType);
        }
        else
        {
            actions = moveDecision.DecideToMove(currentPosition, nextPosition, currentWorldType, bookObjectMap, storyWordMap);
        }
        
        // 行動を送信
        actionSender.SendActionToPresenters(actions);
        // デバッグ用
        // mapPresenter.PrintCurrentMap();
        if (currentWorldType == WorldType.Story) mapPresenter.PrintObjectMap();
        else mapPresenter.PrintWordMap();

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


}
