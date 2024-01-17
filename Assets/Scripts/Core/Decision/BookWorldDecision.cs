using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MVRP.Presenter;

public class BookWorldDecision : MonoBehaviour
{
    /* 
        本の世界での行動を決定する 
        - 次の位置へ移動できることは確定
        - 次の位置に「」付き文字があれば物語の世界に移動
    */
    public Actions DecideAction(List<List<WordPresenter>> bookWordMap, Vector2Int nextPosition)
    {
        // 次の位置のオブジェクトを取得
        var nextWord = bookWordMap[nextPosition.y][nextPosition.x];
        // 次の位置に何もなければ本の世界に留まる
        if (nextWord != null)
        {
            // 次の位置に「」付き文字があれば物語の世界に移動
            if (nextWord.wordState.objectType != ObjectType.None) // 要修正
            {
                return new Actions(nextPosition, WorldType.Story);
            }
        }
        //  「」付き文字でなければ本の世界に留まる
        return new Actions(nextPosition, WorldType.Book);
    }
}
