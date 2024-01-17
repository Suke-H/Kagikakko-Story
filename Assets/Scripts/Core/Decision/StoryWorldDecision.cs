using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MVRP.Presenter;

public class StoryWorldDecision : MonoBehaviour
{
    /* 
        物語の世界での行動を決定する 
        - 物語世界のままなのは確定
        - 次の位置に何もなければ移動できる
    */
    public Actions DecideAction(List<List<ObjectPresenter>> storyObjectMap, Vector2Int currentPosition,  Vector2Int nextPosition)
    {
        // 移動先に何もない場合のみ移動できる
        var nextObject = storyObjectMap[nextPosition.y][nextPosition.x];
        // if (nextObject.objectState.objectType == ObjectType.None) // 要修正
        if (nextObject == null)
        {
            return new Actions(nextPosition, WorldType.Story);
        }
        else
        {
            return new Actions(currentPosition, WorldType.Story);
        }
    }
}
