using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLoader : MonoBehaviour
{
    [SerializeField] private List<StageData> stageDataList;
    
    private StageData stageData;

    public StageData Load(int StageNo)
    {
        // ステージ番号に応じてデータ読み込み
        stageData = stageDataList[StageNo];

        return stageData;
    }

}
