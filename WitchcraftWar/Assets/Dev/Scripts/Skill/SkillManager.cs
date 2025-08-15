using Common.EnumExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillManager
{
    private static readonly Dictionary<SkillIDType, Skill> skillCacheDict = new();
    private static readonly HashSet<Skill> useSkillDict = new();

    private static string path = "Prefabs/Skill";

    public static void Init()
    {
        new GameObject("-------------Skill-----------------");

        foreach (SkillIDType type in Enum.GetValues(typeof(SkillIDType)))
        {
            string sType = type.EnumToString();

            GameObject go = Resources.Load<GameObject>($"{path}/{sType}");
            Skill skill = go.GetComponent<Skill>();

            skill.Init(DataServices.GetData<Table.SkillTable, TableData.Skill>(sType));

            skillCacheDict.Add(type, skill);
        }
    }

    public static void Clear()
    {

    }
}
