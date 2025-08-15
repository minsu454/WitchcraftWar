using Common.EnumExtensions;
using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class AnimatorContainer : IInit
{
    private readonly Dictionary<Enum, RuntimeAnimatorController> characterDic = new Dictionary<Enum, RuntimeAnimatorController>();  //character데이터 담아주는 dictionary

    public void Init()
    {
        CreateStringKey<EnemyIDType>("Animator/Monster");
        CreateintKey<SkillIDType>("Animator/Skill");
    }

    /// <summary>
    /// dictionary enum 값으로 만들어주는 함수
    /// </summary>
    private void CreateStringKey<T>(string path) where T : Enum
    {
        foreach (T type in Enum.GetValues(typeof(T)))
        {
            string sType = type.EnumToString();
            string name = DataServices.GetData<Table.MonsterTable, TableData.Monster>(sType).Name;

            RuntimeAnimatorController animator = Resources.Load<RuntimeAnimatorController>($"{path}/{name}");

            characterDic.Add(type, animator);
        }
    }

    /// <summary>
    /// dictionary enum 값으로 만들어주는 함수
    /// </summary>
    private void CreateintKey<T>(string path) where T : Enum
    {
        foreach (T type in Enum.GetValues(typeof(T)))
        {
            string sType = type.EnumToString();
            RuntimeAnimatorController animator = Resources.Load<RuntimeAnimatorController>($"{path}/{sType}");

            characterDic.Add(type, animator);
        }
    }

    /// <summary>
    /// animator 리턴해주는 함수
    /// </summary>
    public RuntimeAnimatorController ReturnAnimator(Enum type)
    {
        if (!characterDic.TryGetValue(type, out RuntimeAnimatorController result))
        {
            Debug.Log($"Is Not Find PlayerClassDic {type}");
            return null;
        }

        return result;
    }
}
