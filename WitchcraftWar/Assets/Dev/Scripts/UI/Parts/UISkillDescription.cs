using Common.EnumExtensions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISkillDescription : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI RankTypeText;
    [SerializeField] private TextMeshProUGUI AttackText;
    [SerializeField] private TextMeshProUGUI CoolTimeText;
    [SerializeField] private TextMeshProUGUI AttackTypeText;
    [SerializeField] private TextMeshProUGUI AttributeTypeText;
    [SerializeField] private TextMeshProUGUI DescriptionText;

    /// <summary>
    /// 스킬 설명 세팅해주는 함수
    /// </summary>
    public void Set(TableData.Skill data)
    {
        nameText.text = data.Name;
        AttackText.text = data.MaxAtk.ToString();
        CoolTimeText.text = data.CoolTime.ToString();
        DescriptionText.text = data.Description;

        RankTypeText.text = ReturnRankTypeKorean(data.RankType);
        AttackTypeText.text = ReturnAttackTypeKorean(data.AttackType);
        AttributeTypeText.text = ReturnAttributeTypeKorean(data.AttributeType);
    }

    /// <summary>
    /// 랭크 한국어로 변환 함수
    /// </summary>
    private string ReturnRankTypeKorean(RankType type)
    {
        string temp = string.Empty;

        switch (type)
        {
            case RankType.Common:
                temp = "일반";
                break;
            case RankType.Uncommon:
                temp = "희귀";
                break;
            case RankType.Rare:
                temp = "영웅";
                break;
            case RankType.Epic:
                temp = "전설";
                break;
            case RankType.Legendary:
                temp = "선조";
                break;
            case RankType.Mythic:
                temp = "천벌";
                break;
        }

        return temp;
    }

    /// <summary>
    /// 공격타입 한국어로 변환
    /// </summary>
    private string ReturnAttackTypeKorean(AttackType type)
    {
        string temp = string.Empty;

        switch (type)
        {
            case AttackType.Short:
                temp = "근거리";
                break;
            case AttackType.Middle:
                temp = "중거리";
                break;
            case AttackType.Long:
                temp = "원거리";
                break;
        }

        return temp;
    }

    /// <summary>
    /// 스킬타입 한국어로 변환
    /// </summary>
    private string ReturnAttributeTypeKorean(AttributeType type)
    {
        string temp = string.Empty;

        switch (type)
        {
            case AttributeType.Earth:
                temp = "땅";
                break;
            case AttributeType.Fire:
                temp = "불";
                break;
            case AttributeType.Water:
                temp = "물";
                break;
            case AttributeType.Electric:
                temp = "전기";
                break;
        }

        return temp;
    }

}
