using Common.EnumExtensions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIEnemyInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemyName;             //적 이름 텍스트
    [SerializeField] private TextMeshProUGUI enemyDescription;      //적 설명 텍스트
    [SerializeField] private TextMeshProUGUI enemyStat;             //적 스텟 텍스트

    public void Init()
    {
        enemyName.text = "";
        enemyDescription.text = "";
        enemyStat.text = "";
    }

    public void Set(EnemyIDType type)
    {
        string sType = type.EnumToString();
        TableData.Monster data = DataServices.GetData<Table.MonsterTable, TableData.Monster>(sType);

        enemyName.text = data.Name;
        enemyDescription.text = data.Description;

        enemyStat.text =
$@"Attack            : {data.Attack}
HP                 : {data.MaxHP}
MoveSpeed   : {data.MoveSpeed}
AttackRange : {data.AttackRange}";
    }
}
