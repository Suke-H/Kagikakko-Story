using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MVRP.Presenter;

public class StageLoader : MonoBehaviour
{
    [SerializeField] private List<StageData> stageDataList;

    [SerializeField] private PlayerPresenter playerPresenter;
    [SerializeField] private GoalPresenter goalPresenter;
    [SerializeField] private MapPresenter mapPresenter;
    
    private StageData stageData;

    public void Load(int StageNo)
    {
        // ステージ番号に応じてデータ読み込み
        stageData = stageDataList[StageNo];
        
        // プレイヤーの初期化
        playerPresenter.Initialize(stageData.playerInitPosition);
        // ゴールの初期化
        goalPresenter.Initialize(stageData.goalObjectType);
        // マップの初期化
        stageData.LoadCSV(); // CSV読み込み
        mapPresenter.Initialize(stageData.bookMap, stageData.storyMap);
    }

}
