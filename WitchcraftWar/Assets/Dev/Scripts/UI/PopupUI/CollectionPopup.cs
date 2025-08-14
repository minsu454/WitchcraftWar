using Common.Event;
using Common.SceneEx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionPopup : BasePopupUI
{
    [SerializeField] private UIScrollView scrollView;
    [SerializeField] private UIEnemyInfo enemyInfo;

    public override void Init<T>(T option)
    {
        base.Init(option);

        enemyInfo.Init();
        SetScrollView();
    }

    /// <summary>
    /// 맵 선택창 띄워주는 함수
    /// </summary>
    public void SetScrollView()
    {
        scrollView.CreateItem<EnemyIDType>(CustomClickEvent);
    }

    /// <summary>
    /// 버튼 클릭 이벤트
    /// </summary>
    /// <param name="type"></param>
    public void CustomClickEvent(object type)
    {
        enemyInfo.Set((EnemyIDType)type);
    }
}
