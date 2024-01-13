using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/StageData")]
[System.Serializable]
public class StageData : ScriptableObject
{
    public List<List<ObjectType>> bookMap;
    public List<List<ObjectType>> storyMap;

    public List<ObjectType> testMap;

    public Vector2Int playerInitPosition;
    public ObjectType goalObjectType;
}

