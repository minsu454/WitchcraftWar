using Common.EnumExtensions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class UISkillBtn : MonoBehaviour
{
    [SerializeField] private SkillIDType skillID;
    public SkillIDType IDType { get { return skillID; } }

    [SerializeField] private TextMeshProUGUI countText;
    private Skill skill;

    private void Start()
    {
        if(skillID != SkillIDType.None)
            skill = SkillManager.GetSkill(skillID);
    }

    private void Update()
    {
        if (skill == null)
            return;

        if (skill.Active is false)
            countText.text = "";
        else
            countText.text = skill.Count.ToString();


    }
}
