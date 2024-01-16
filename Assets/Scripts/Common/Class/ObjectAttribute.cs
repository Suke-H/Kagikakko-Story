using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class ObjectAttribute
{
    public ObjectType objectType;
    public bool canPush;

    public ObjectAttribute(ObjectType objectType, bool canPush)
    {
        this.objectType = objectType;
        this.canPush = canPush;
    }

    // クローン
    public ObjectAttribute Clone()
    {
        return new ObjectAttribute(objectType, canPush);
    }
    
    public void Print()
    {
        Debug.Log("ObjectAttribute: " + " " + objectType + " " + canPush);
    }
}
