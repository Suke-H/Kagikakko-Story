using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerState
{
    public Vector2Int position;
    public bool isGoal;

    public WorldType worldType;
    public ObjectType objectType;

    public PlayerState(Vector2Int position, bool isGoal, WorldType worldType, ObjectType objectType)
    {
        this.position = position;
        this.isGoal = isGoal;
        this.worldType = worldType;
        this.objectType = objectType;
    }

    // クローン
    public PlayerState Clone()
    {
        return new PlayerState(position, isGoal, worldType, objectType);
    }
    
    public void Print()
    {
        Debug.Log("PlayerState: " + position + " " + isGoal + " " + worldType + " " + objectType);
    }
}


