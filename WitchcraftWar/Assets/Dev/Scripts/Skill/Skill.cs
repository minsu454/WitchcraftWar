using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected TableData.Skill skillData;            //스킬 데이터

    /// <summary>
    /// 스킬 초기화
    /// </summary>
    public virtual void Init(TableData.Skill skillData)
    {
        this.skillData = skillData;
    }

    /// <summary>
    /// 스킬 소환
    /// </summary>
    public abstract void Spawn();
}
