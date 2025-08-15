using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected TableData.Skill skillData;            //스킬 데이터
    public TableData.Skill Data { get { return skillData; } }

    private bool active = false;
    public bool Active
    {
        get { return active; }
        set
        {
            active = value;
            if (active is false)
                Reset();
        }
    }

    private int count;          //들고있는 갯수


    /// <summary>
    /// 초기화
    /// </summary>
    public virtual void Init(TableData.Skill skillData)
    {
        this.skillData = skillData;
    }

    /// <summary>
    /// 스킬 소환
    /// </summary>
    public abstract void Spawn();

    /// <summary>
    /// 리셋
    /// </summary>
    public abstract void Reset();
}
