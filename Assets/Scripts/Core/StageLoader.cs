using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MVPR.Presenter;

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

        // CSV読み込み
        stageData.LoadCSV();

        // マップ確認
        mapPresenter.Initialize(stageData.bookMap, stageData.storyMap);
    }

}
