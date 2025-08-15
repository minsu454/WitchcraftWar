using Common.Pool;
using System;
using UnityEngine;

public class SandFist : Skill
{
    [SerializeField] private ObjectPool<Projectile> projectilePool;     //총알 오브젝트 풀
    [SerializeField] private GameObject baseProjectilePrefab;           //총알 기본 프리팹

    public override void Reset()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 초기화
    /// </summary>
    public override void Init(TableData.Skill skillData)
    {
        base.Init(skillData);
        //projectilePool = new ObjectPool<Projectile>("Projectile", baseProjectilePrefab, null, 10);
    }

    public override void Spawn()
    {
        
    }
}
