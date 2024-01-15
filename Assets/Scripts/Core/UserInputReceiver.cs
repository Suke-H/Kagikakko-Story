using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

using MVRP.Presenter;

public class UserInputReceiver : MonoBehaviour
{
    [SerializeField] private ActionDecisionMaker actionDecisionMaker;
    
    public async UniTask RespondToUserInput()
    {
        // 何かキーが押されるまで待つ
        await UniTask.WaitUntil(() => Input.anyKeyDown);

        // ユーザーの入力を取得する
        UserInput userInput = GetUserInput();

        // ユーザーの入力に応じて行動を決定する
        actionDecisionMaker.DecideAction(userInput);
        
    }
    public UserInput GetUserInput()
    {
        UserInput input = UserInput.None;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            input = UserInput.Up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            input = UserInput.Down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            input = UserInput.Left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            input = UserInput.Right;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            input = UserInput.Quit;
        }

        return input;
    }

}
