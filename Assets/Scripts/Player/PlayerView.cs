using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVRP.View
{
    public class PlayerView : MonoBehaviour
    {
        public void Initialize(Vector2Int position)
        {
            Debug.Log($"PlayerView.Initialize: {position}");
        }

        public void Move(Vector2Int nextPosition)
        {
            Debug.Log($"PlayerView.Move: {nextPosition}");
        }
    }

}

