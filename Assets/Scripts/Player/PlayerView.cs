using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVPR.View
{
    public class PlayerView : MonoBehaviour
    {
        public void Initialize(Vector2Int position)
        {
            Debug.Log($"PlayerView.Initialize: {position}");
        }

        public void Move(UserInput userInput)
        {
            Debug.Log($"PlayerView.Move: {userInput}");
        }
    }

}

