using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    [SerializeField] private StageLoader stageLoader;
    [SerializeField] private UserInputController userInputController;

    private int stageNo;
    private StageData stageData;

    async void Start()
    {
        stageNo = 0;

        // ステージのロード
        stageLoader.Load(stageNo);

        // 開始
        await GameLoop();
    }

    public async UniTask GameLoop()
    {
        while (true)
        {
            // ユーザーの入力に応じてプレイヤーを移動させる
            await userInputController.RespondToUserInput();
        }
    } 

}
