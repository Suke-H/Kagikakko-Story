using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitDecision : MonoBehaviour
{
    public Actions DecideToQuit(Vector2Int currentPosition, WorldType currentWorldType)
    {
        Actions actions = new Actions(currentPosition, currentWorldType);
        // 物語世界の場合は本の世界に戻る
        if ( currentWorldType == WorldType.Story)
        {
            actions = new Actions(currentPosition, WorldType.Book);
        }

        return actions;
    }
}
