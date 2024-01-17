using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MVRP.Presenter;

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

    public static void PrintObjectMap(List<List<ObjectPresenter>> data)
    {

        Debug.Log($"<<Story Object Map>>");
        Debug.Log("---");

        foreach (List<ObjectPresenter> row in data)
        {
            string line = "";
            foreach (ObjectPresenter obj in row)
            {
                if (obj == null)
                {
                    line += "None,";
                    continue;
                }
                line += obj.objectState.objectType + ",";
            }
            Debug.Log(line);
        }
    }

    public static void PrintWordMap(List<List<WordPresenter>> data)
    {

        Debug.Log($"<< Book Word Map>>");
        Debug.Log("---");

        foreach (List<WordPresenter> row in data)
        {
            string line = "";
            foreach (WordPresenter word in row)
            {
                if (word == null)
                {
                    line += "None,";
                    continue;
                }
                line += word.wordState.objectType + ",";
            }
            Debug.Log(line);
        }
    }
}
