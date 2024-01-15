using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDecision : MonoBehaviour
{

    [SerializeField] private BookWorldDecision bookWorldDecision;
    [SerializeField] private StoryWorldDecision storyWorldDecision;

    public Actions DecideToMove(Vector2Int currentPosition, Vector2Int nextPosition, WorldType currentWorldType, List<List<ObjectType>> currentMap)
    {
        Actions actions = new Actions(currentPosition, currentWorldType);
        // マップの範囲外には移動できない
        if (IsInsideMapArea(currentMap, nextPosition))
        {
            // 本の世界
            if (currentWorldType == WorldType.Book)
            {
                actions = bookWorldDecision.DecideAction(currentMap, nextPosition);
            }
            // 物語の世界
            else
            {
                actions = storyWorldDecision.DecideAction(currentMap, currentPosition, nextPosition);
            }
        }

        return actions;
    }

    public bool IsInsideMapArea(List<List<ObjectType>> currentMap, Vector2Int nextPosition)
    {
        // マップの範囲外には移動できない
        if (nextPosition.x < 0 || nextPosition.x >= currentMap[0].Count ||
            nextPosition.y < 0 || nextPosition.y >= currentMap.Count)
        {
            return false;
        }

        return true;
    }
}
