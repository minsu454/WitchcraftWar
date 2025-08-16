using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkillBtn : MonoBehaviour
{
    [SerializeField] private SkillIDType skillID;
    public SkillIDType IDType { get { return skillID; } }

    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Image image;
    [SerializeField] private RectTransform CoolTimeTr;
    private Skill skill;

    private void Start()
    {
        if (skillID != SkillIDType.None)
        {
            skill = SkillManager.GetSkill(skillID);
            image.color = skill.ProjectileColor;
        }
    }

    private void Update()
    {
        if (skill == null)
            return;

        if (skill.Active is false)
        {
            CoolTimeTr.localScale = new Vector2(0, 1);
            countText.text = "";
        }
        else
        {
            float maxTime = skill.Data.CoolTime / skill.Count;
            float clamp = Mathf.Clamp01(skill.CurTime / maxTime);

            CoolTimeTr.localScale = new Vector2(clamp, 1);
            countText.text = skill.Count.ToString();
        }
    }
}
