using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVRP.Model
{
    public class ObjectModel : MonoBehaviour
    {
        public ObjectState objectState { get; private set; }

        public void Initialize(ObjectType objectType, int x, int y)
        {
            objectState = new ObjectState(objectType, new Vector2Int(x, y), false);
            objectState.Print();
        }
    }
}  

