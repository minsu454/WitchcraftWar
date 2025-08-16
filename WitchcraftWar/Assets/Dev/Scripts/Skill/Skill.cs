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

    [SerializeField] private Color32 projectileColor;       //투사체 색깔
    public Color32 ProjectileColor { get { return projectileColor; } }

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
    public virtual void Spawn()
    {
        count++;
        active = true;
    }

    public bool CanUpgrade()
    {
        if (count < upgradeCount)
            return false;

        count -= upgradeCount;

        if (count == 0)
        {
            active = false;
        }

        return true;
    }

    /// <summary>
    /// 리셋
    /// </summary>
    public abstract void Reset();
}
