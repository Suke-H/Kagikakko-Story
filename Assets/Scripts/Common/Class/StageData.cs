using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/StageData")]
[System.Serializable]
public class StageData : ScriptableObject
{

    public TextAsset bookMapCSV;
    public TextAsset storyMapCSV;

    public Vector2Int playerInitPosition;
    public ObjectType goalObjectType;

    // CSV読み込み先
    public List<List<ObjectType>> bookMap { get; private set; }
    public List<List<ObjectType>> storyMap { get; private set; }

    public void LoadCSV()
    {   
        // CSVを二次元リストに変換
        bookMap = CSVReader.Read(bookMapCSV);
        storyMap = CSVReader.Read(storyMapCSV);
    }
}

