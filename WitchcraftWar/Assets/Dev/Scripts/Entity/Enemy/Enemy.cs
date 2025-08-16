using Common.EnumExtensions;
using Common.Yield;
using System;
using System.Collections;
using UnityEngine;

public class Enemy : Entity, IObjectPoolable<Enemy>
{
    public event Action<Enemy> ReturnEvent;         //ObjectPool리턴 이벤트 변수
    public event Action EnemyDieEvent;              //커스텀 리턴 이벤트 변수

    [Header("Enemy")]
    [SerializeField] private Animator animator;                 //애니메이터
    [SerializeField] private CircleCollider2D circleCollider;   //콜라이더
    private const float colliderRadius = 0.5f;                  //콜라이더 범위 기본 값
    [SerializeField] private TriggerDetector2D triggerDetector; //공격범위 콜라이더

    private EnemyMovement enemyMovement;
    private Coroutine coGiveDamage;                             //일정 시간마다 데미지 주는 코루틴 저장 변수

    private int coin;
    public int Coin { get { return coin; } }

    private void Start()
    {
        triggerDetector.EnterEvent += TriggerEnter2DEvent;
        triggerDetector.ExitEvent += TriggerExit2DEvent;

        enemyMovement = GetComponent<EnemyMovement>();
    }

    /// <summary>
    /// 적 세팅 함수
    /// </summary>
    public void Set(EnemyIDType idType, int round)
    {
        string sType = idType.EnumToString();
        TableData.Monster data = DataServices.GetData<Table.MonsterTable, TableData.Monster>(sType);

        attack = data.Attack + (round * data.Attack * data.AttackMul);
        moveSpeed = data.MoveSpeed;
        maxHp = data.MaxHP + (round * data.MaxHP * data.MaxHPMul);
        curHp = maxHp;
        circleCollider.radius *= data.AttackRange;
        attackSpeed = data.AttackSpeed;
        coin = data.Coin;

        animator.runtimeAnimatorController = Managers.Container.ReturnAnimator(idType);

        SetHpBarUI();
    }

    /// <summary>
    /// 죽을 때 실행 함수
    /// </summary>
    protected override void Die()
    {
        GameManager.Instance.SetCoin(Coin);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 플레이어 공격 콜라이더 함수
    /// </summary>
    private void TriggerEnter2DEvent(Collider2D col)
    {
        if (col.CompareTag("Player") && coGiveDamage == null)
        {
            Player player = col.GetComponent<Player>();

            enemyMovement.Stop();
            coGiveDamage = StartCoroutine(CoGiveDamage(player));
        }
    }

    /// <summary>
    /// 플레이어 공격 콜라이더 함수
    /// </summary>
    private void TriggerExit2DEvent(Collider2D col)
    {
        if (col.CompareTag("Player") && coGiveDamage != null)
        {
            StopCoroutine(coGiveDamage);
            coGiveDamage = null;
        }
    }

    /// <summary>
    /// 일정 시간마다 데미지 주는 함수
    /// </summary>
    private IEnumerator CoGiveDamage(Player player)
    {
        while (true)
        {
            player.GetDamage(attack);
            yield return YieldCache.WaitForSeconds(AttackSpeed);
        }
    }

    private void OnDisable()
    {
        circleCollider.radius = colliderRadius;

        EnemyDieEvent?.Invoke();
        EnemyDieEvent = null;

        ReturnEvent.Invoke(this);
    }
}
