using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class ObjectState
{
    public ObjectType objectType;
    public Vector2Int position;
    public bool canPush;

    public ObjectState(ObjectType objectType, Vector2Int position, bool canPush)
    {
        this.objectType = objectType;
        this.position = position;
        this.canPush = canPush;
    }

    // クローン
    public ObjectState Clone()
    {
        return new ObjectState(objectType, position, canPush);
    }
    
    public void Print()
    {
        Debug.Log("ObjectState: " + " " + objectType + " " + position +  " "  + canPush);
    }
}
