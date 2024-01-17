using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WordState
{
    public ObjectType objectType;
    public Vector2Int position;

    public WordState(ObjectType objectType, Vector2Int position)
    {
        this.objectType = objectType;
        this.position = position;
    }

    // クローン
    public WordState Clone()
    {
        return new WordState(objectType, position);
    }
    
    public void Print()
    {
        Debug.Log("WordState: " + " " + objectType + " " + position);
    }
}
