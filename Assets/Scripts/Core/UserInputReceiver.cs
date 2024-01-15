using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

using MVRP.Presenter;

public class UserInputReceiver : MonoBehaviour
{
    [SerializeField] private PlayerPresenter playerPresenter;

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
    
    public async UniTask RespondToUserInput()
    {
        // 何かキーが押されるまで待つ
        await UniTask.WaitUntil(() => Input.anyKeyDown);

        // ユーザーの入力を取得する
        UserInput userInput = GetUserInput();

        // UserInputが上下左右の場合はプレイヤーを移動させる
        if (userInput == UserInput.Up ||
            userInput == UserInput.Down ||
            userInput == UserInput.Left ||
            userInput == UserInput.Right)
        {
            playerPresenter.Move(userInput);
        }
        
        // UserInputがQuitの場合は本の世界に戻る

    }

}
