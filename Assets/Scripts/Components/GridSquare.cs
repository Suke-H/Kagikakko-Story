using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour
{

    [SerializeField] private TextMeshPro text;
    [SerializeField] private TextMeshPro kakkoLeft;
    [SerializeField] private TextMeshPro kakkoRight;

    public void WriteText(string textToWrite)
    {
        text.text = textToWrite;
    }

    public void WriteKakko()
    {
        kakkoLeft.text = "「";
        kakkoRight.text = "」";
        // kakkoLeft.color = color;
        // kakkoRight.color = color;
    }
}
