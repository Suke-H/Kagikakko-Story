using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVRP.View
{
    public class ObjectView : MonoBehaviour
    {
        public void Initialize(ObjectType objectType)
        {
            Debug.Log($"ゴールの初期化: {objectType}");
        }
    }
}


