using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVPR.Model;
using MVPR.View;

namespace MVPR.Presenter
{
    public class GoalPresenter : MonoBehaviour
    {
        [SerializeField] private GoalModel goalModel;
        [SerializeField] private GoalView goalView;

        public void Initialize(ObjectType goalObjectType)
        {
            // モデルの初期化
            goalModel.Initialize(goalObjectType);

            // ビューの初期化
            goalView.Initialize(goalObjectType);
        }

    }

}
