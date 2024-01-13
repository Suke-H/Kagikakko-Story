using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVPR.Model
{
    public class PlayerModel : MonoBehaviour
    {
        private PlayerState playerState;
        
        public void Initialize(Vector2Int position)
        {
            playerState = new PlayerState(position, false, WorldType.Book, ObjectType.BookPlayer);
            playerState.Print();
        }
    }

}
