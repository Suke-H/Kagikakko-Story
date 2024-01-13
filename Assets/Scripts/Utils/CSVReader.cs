using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader
{
    public static List<List<ObjectType>> Read(TextAsset csv)
    {
        List<List<ObjectType>> data = new List<List<ObjectType>>();

        string[] lines = csv.text.Split('\n');

        foreach (string line in lines)
        {
            string[] words = line.Split(',');

            List<ObjectType> row = new List<ObjectType>();

            foreach (string word in words)
            {
                ObjectType type = (ObjectType)int.Parse(word);
                row.Add(type);
            }

            data.Add(row);
        }

        return data;
    }

    public static void Print(string listName, List<List<ObjectType>> data)
    {

        Debug.Log($"<<{listName}>>");
        Debug.Log("---");

        foreach (List<ObjectType> row in data)
        {
            string line = "";
            foreach (ObjectType type in row)
            {
                line += type + ",";
            }
            Debug.Log(line);
        }
    }
}
