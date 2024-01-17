using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MVRP.Presenter;

public class MoveDecision : MonoBehaviour
{

    [SerializeField] private BookWorldDecision bookWorldDecision;
    [SerializeField] private StoryWorldDecision storyWorldDecision;

    public Actions DecideToMove(Vector2Int currentPosition, Vector2Int nextPosition, 
                                WorldType currentWorldType, List<List<WordPresenter>> bookWordMap, List<List<ObjectPresenter>> storyObjectMap)
    {
        Actions actions = new Actions(currentPosition, currentWorldType);
        // マップの範囲外には移動できない
        if (IsInsideMapArea(bookWordMap, nextPosition))
        {
            // 本の世界
            if (currentWorldType == WorldType.Book)
            {
                actions = bookWorldDecision.DecideAction(bookWordMap, nextPosition);
            }
            // 物語の世界
            else
            {
                actions = storyWorldDecision.DecideAction(storyObjectMap, currentPosition, nextPosition);
            }
        }

        return actions;
    }

    public bool IsInsideMapArea<T>(List<List<T>> map, Vector2Int nextPosition)
    {
        // マップの範囲外には移動できない
        if (nextPosition.x < 0 || nextPosition.x >= map[0].Count ||
            nextPosition.y < 0 || nextPosition.y >= map.Count)
        {
            return false;
        }

        return true;
    }
}
