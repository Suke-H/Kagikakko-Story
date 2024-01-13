using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVPR.Model
{
    public class PlayerModel : MonoBehaviour
    {
        public PlayerState playerState;
        
        public void Load(Vector2Int position)
        {
            playerState = new PlayerState(position, false, WorldType.Book, ObjectType.BookPlayer);
        }
    }

}
