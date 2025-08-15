using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillManager
{
    private static readonly Dictionary<SkillIDType, Skill> skillCacheDict = new();
    private static readonly HashSet<Skill> useSkillDict = new();

    public static void Clear()
    {

    }
}
