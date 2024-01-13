using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private StageLoader stageLoader;

    private int stageNo;
    private StageData stageData;

    void Start()
    {
        stageNo = 0;
        stageLoader.Load(stageNo);
    }

}
