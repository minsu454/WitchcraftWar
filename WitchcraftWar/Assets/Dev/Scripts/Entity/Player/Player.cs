using Common.Event;
using Common.Pool;
using UnityEngine;

public class Player : Entity
{
    /// <summary>
    /// 초기화
    /// </summary>
    public void Init()
    {
        SetHpBarUI();
    }

    /// <summary>
    /// 죽을 때 호출 함수
    /// </summary>
    protected override void Die()
    {
        EventManager.Dispatch(GameEventType.GameOver, null);
        gameObject.SetActive(false);
    }
}
