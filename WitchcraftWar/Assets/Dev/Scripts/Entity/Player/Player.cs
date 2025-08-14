using Common.Event;
using Common.Pool;
using UnityEngine;

public class Player : Entity
{
    [Header("Player")]
    [SerializeField] private GameObject baseBulletPrefab;    //총알 기본 프리팹
    [SerializeField] private ObjectPool<Bullet> bulletPool;  //총알 오브젝트 풀

    /// <summary>
    /// 초기화
    /// </summary>
    public void Init()
    {
        new GameObject("-------------BulletPool-----------------");
        bulletPool = new ObjectPool<Bullet>("Bullet", baseBulletPrefab, null, 10);
        SetHpBarUI();
    }

    /// <summary>
    /// ObjectPool에서 총알 빼주는 함수
    /// </summary>
    public Bullet GetBullet()
    {
        return bulletPool.GetObject();
    }

    /// <summary>
    /// 아이템 사용 함수
    /// </summary>
    public void UseItem(TableData.Item data)
    {
        curHp += data.MaxHP;

        if (curHp > maxHp)
            curHp = maxHp;

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
