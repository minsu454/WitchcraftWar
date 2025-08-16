using Common.EnumExtensions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISkillBtn : MonoBehaviour
{
    [SerializeField] private SkillIDType skillID;
    public SkillIDType IDType { get { return skillID; } }
}
