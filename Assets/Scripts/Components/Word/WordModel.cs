using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVRP.Model
{
    public class WordModel : MonoBehaviour
    {
        public WordState wordState { get; private set; }

        public void Initialize(ObjectType objectType, int x, int y)
        {
            wordState = new WordState(objectType, new Vector2Int(x, y));
            wordState.Print();
        }
    }
}  

