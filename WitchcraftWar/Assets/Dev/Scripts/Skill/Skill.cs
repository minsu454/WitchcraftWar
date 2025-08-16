using Common.Pool;
using System;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected TableData.Skill skillData;            //스킬 데이터
    public TableData.Skill Data { get { return skillData; } }

    private bool active = false;
    public bool Active
    {
        get { return active; }
    }

    private int count = 0;      //들고있는 갯수
    public int Count { get { return count; } }
    private int upgradeCount = 3;

    private float curTime = 0;
    public float CurTime { get { return curTime; } }

    [Header("Skill")]
    [SerializeField] private Color32 projectileColor;       //투사체 색깔
    public Color32 ProjectileColor { get { return projectileColor; } }

    [SerializeField] private ObjectPool<Projectile> projectilePool;     //총알 오브젝트 풀
    [SerializeField] private GameObject baseProjectilePrefab;           //총알 기본 프리팹

    private Transform shootTr;

    /// <summary>
    /// 초기화
    /// </summary>
    public virtual void Init(TableData.Skill skillData)
    {
        this.skillData = skillData;

        projectilePool = new ObjectPool<Projectile>($"{nameof(Projectile)}", baseProjectilePrefab, null, 5);
        shootTr = EntityManager.player.transform;
    }

    /// <summary>
    /// 스킬 소환
    /// </summary>
    public virtual void Spawn()
    {
        count++;
        active = true;
    }

    private void Update()
    {
        if (active is false)
            return;

        curTime += Time.deltaTime;

        if (curTime > skillData.CoolTime / count)
        {
            curTime -= skillData.CoolTime / count;
            Projectile projectile = projectilePool.GetObject();

            projectile.transform.position = shootTr.position;
            projectile.gameObject.SetActive(true);
            projectile.Set(projectileColor, skillData.MaxAtk);
        }
    }

    public bool CanUpgrade()
    {
        if (count < upgradeCount)
            return false;

        count -= upgradeCount;

        if (count == 0)
        {
            active = false;
            curTime = 0;
        }

        return true;
    }

    /// <summary>
    /// 리셋
    /// </summary>
    public abstract void Reset();
}
