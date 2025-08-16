using Common.EnumExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillManager
{
    private static readonly Dictionary<SkillIDType, Skill> skillCacheDict = new();

    private static string path = "Prefabs/Skill";

    public static void Init()
    {
        new GameObject("-------------Skill-----------------");

        foreach (SkillIDType type in Enum.GetValues(typeof(SkillIDType)))
        {
            if (type is SkillIDType.None)
                continue;

            string sType = type.EnumToString();

            GameObject clone = GameObject.Instantiate(Resources.Load<GameObject>($"{path}/{sType}"));
            Skill skill = clone.GetComponent<Skill>();

            skill.Init(DataServices.GetData<Table.SkillTable, TableData.Skill>(type));

            skillCacheDict.Add(type, skill);
        }
    }

    /// <summary>
    /// 스킬 데이터 전송 함수
    /// </summary>
    public static TableData.Skill GetSkillData(SkillIDType type)
    {
        if (!skillCacheDict.TryGetValue(type, out var skill))
        {
            Debug.LogError($"'{type}'Skill is None.");
            return null;
        }

        return skill.Data;
    }

    /// <summary>
    /// 산 스킬 함수
    /// </summary>
    public static void BuySkill()
    {

    }

    /// <summary>
    /// 업그레이드 스킬 함수
    /// </summary>
    public static void UpgradeSkill(SkillIDType type)
    {

    }

    public static void Clear()
    {

    }
}
