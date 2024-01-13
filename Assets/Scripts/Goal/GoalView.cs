using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVPR.View
{
    public class GoalView : MonoBehaviour
    {
        public void Initialize(ObjectType goalObjectType)
        {
            Debug.Log($"ゴールの初期化: {goalObjectType}");
        }
    }
}

