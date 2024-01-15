using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryWorldDecision : MonoBehaviour
{
    /* 
        物語の世界での行動を決定する 
        - 物語世界のままなのは確定
        - 次の位置に何もなければ移動できる
    */
    public Actions DecideAction(List<List<ObjectType>> currentMap, Vector2Int currentPosition,  Vector2Int nextPosition)
    {
        // 移動先に何もない場合のみ移動できる
        if (currentMap[nextPosition.y][nextPosition.x] == ObjectType.None)
        {
            return new Actions(nextPosition, WorldType.Story);
        }
        else
        {
            return new Actions(currentPosition, WorldType.Story);
        }
    }
}
