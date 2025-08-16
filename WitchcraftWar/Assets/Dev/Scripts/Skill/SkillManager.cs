using Common.EnumExtensions;
using DG.Tweening.Plugins;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillManager
{
    private static readonly Dictionary<SkillIDType, Skill> skillCacheDict = new();
    private static readonly Dictionary<RankType, List<SkillIDType>> rankDict = new();

    private static string path = "Prefabs/Skill";

    private static int curSkillCount = 0;
    public static int CurSkillCount { get { return curSkillCount; } }
    private static int maxSkillCount = 25;
    public static int MaxSkillCount { get { return maxSkillCount; } }

    private static int skillBuyPrice = 20;
    public static int SkillBuyPrice { get { return skillBuyPrice; } }

    private static float[] probArr = { 75, 20, 5 };

    private static int skillTypeCount = 3;
    private static int skillUpgradeCount = 2;


    public static void Init()
    {
        new GameObject("-------------Skill-----------------");

        foreach (SkillIDType type in Enum.GetValues(typeof(SkillIDType)))
        {
            if (type is SkillIDType.None)
                continue;

            string sType = type.EnumToString();

            GameObject clone = GameObject.Instantiate(Resources.Load<GameObject>($"{path}/{sType}"));
            clone.name = sType;
            Skill skill = clone.GetComponent<Skill>();
            var data = DataServices.GetData<Table.SkillTable, TableData.Skill>(type);

            skill.Init(data);

            if (rankDict.TryGetValue(data.RankType, out List<SkillIDType> list) is false)
            {
                list = new List<SkillIDType>();
            }
            list.Add(type);
            rankDict[data.RankType] = list;

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
    /// 스킬 데이터 전송 함수
    /// </summary>
    public static Skill GetSkill(SkillIDType type)
    {
        if (!skillCacheDict.TryGetValue(type, out var skill))
        {
            Debug.LogError($"'{type}'Skill is None.");
            return null;
        }

        return skill;
    }

    /// <summary>
    /// 산 스킬 함수
    /// </summary>
    public static void BuySkill()
    {
        if (GameManager.Instance.Coin - skillBuyPrice < 0 || curSkillCount + 1 > maxSkillCount)
            return;

        GetRandomRank();

        curSkillCount++;
        GameManager.Instance.SetCoin(-skillBuyPrice);
        skillBuyPrice++;
    }

    /// <summary>
    /// 확률로 스킬 랭크뽑기 함수
    /// </summary>
    public static void GetRandomRank()
    {
        int randNum = UnityEngine.Random.Range(0, 100);
        float temp = 0;
        int i;

        for (i = 0; i < probArr.Length; i++)
        {
            temp += probArr[i];
            if (randNum < temp)
                break;
        }

        RankType type = (RankType)i;
        GetRandomSkill(type);
    }

    /// <summary>
    /// 랜덤스킬뽑기 함수
    /// </summary>
    private static void GetRandomSkill(RankType rankType)
    {
        int randNum = UnityEngine.Random.Range(0, skillTypeCount);
        SkillIDType idType = rankDict[rankType][randNum];

        skillCacheDict[idType].Spawn();
    }

    /// <summary>
    /// 업그레이드 스킬 함수
    /// </summary>
    public static void UpgradeSkill(SkillIDType type)
    {
        if (skillCacheDict.TryGetValue(type, out Skill skill) is false)
            return;

        if (skill.CanUpgrade() is false)
            return;

        curSkillCount -= skillUpgradeCount;

        GetRandomSkill(skill.Data.RankType + 1);
    }

    public static void Clear()
    {
        skillCacheDict.Clear();
        rankDict.Clear();
    }
}
