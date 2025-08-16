using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;                   //이동시 호출될 이벤트

    [Header("Entity")]
    [SerializeField] protected float curHp;                     //현재 체력
    [SerializeField] protected float maxHp;                     //최대 체력
    [SerializeField] protected float attack;                    //공격력
    public float Attack { get { return attack; } }
    [SerializeField] protected float attackSpeed;               //공격력 속도
    public float AttackSpeed { get { return attackSpeed; } }
    [SerializeField] protected int attackRange;                 //공격 사거리
    public int AttackRange { get { return attackRange; } } 
    [SerializeField] protected float moveSpeed;                 //이동 속도
    public float MoveSpeed { get { return moveSpeed; } }

    [SerializeField] private Transform hpBarTr;

    /// <summary>
    /// 등록된 MoveEvent를 모두 실행해주는 함수
    /// </summary>
    public void CallMoveEvent(Vector2 dir)
    {
        OnMoveEvent?.Invoke(dir);
    }

    /// <summary>
    /// 데미지 입는 함수
    /// </summary>
    public void GetDamage(float damage)
    {
        curHp -= damage;

        if (curHp <= 0)
        {
            Die();
        }

        SetHpBarUI();
    }

    /// <summary>
    /// HPBar UI 재설정해주는 함수
    /// </summary>
    protected void SetHpBarUI()
    {
        hpBarTr.localScale = new Vector2((float)curHp/maxHp, 1);
    }

    /// <summary>
    /// 죽을 때 호출 함수
    /// </summary>
    protected abstract void Die();
}
