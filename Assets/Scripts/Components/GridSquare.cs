using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridSquare : MonoBehaviour
{

    [SerializeField] private TextMeshPro text;

    public void WriteText(string textToWrite)
    {
        text.text = textToWrite;
    }
   
}
