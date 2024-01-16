using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVRP.Model
{
    public class ObjectModel : MonoBehaviour
    {
        private ObjectType objectType;
        private ObjectAttribute objectAttribute;

        public void Initialize(ObjectType objectType)
        {
            objectAttribute = new ObjectAttribute(objectType, false);
        }
    }
}  

