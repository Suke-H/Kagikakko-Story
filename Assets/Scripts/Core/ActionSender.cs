using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVRP.Presenter;
public class ActionSender : MonoBehaviour
{
    [SerializeField] private PlayerPresenter playerPresenter;
    [SerializeField] private MapPresenter mapPresenter;

    public void SendActionToPresenters(Actions actions)
    {
        // プレイヤーの行動を送信
        playerPresenter.Move(actions.nextPlayerPosition);

        // マップの行動を送信
        mapPresenter.SwitchWorld(actions.nextWorldType);
    }
}
