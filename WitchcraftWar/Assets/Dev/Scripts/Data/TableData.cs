using System;

public class TableData
{
    [Serializable]
    public class Skill : IData
    {
        public object ID { get { return SkillID; } }

        public int SkillID;
        public string Name;
        public string Description;
        public RankType RankType;
        public AttributeType AttributeType;
        public AttackType AttackType;
        public int MaxAtk;
        public float CoolTime;
        public int TargetCount;
        //public bool 
    }

    [Serializable]
    public class Monster : IData
    {
        public object ID { get { return MonsterID; } }

        public string MonsterID;
        public string Name;
        public string Description;
        public int Attack;
        public float AttackMul;
        public int MaxHP;
        public float MaxHPMul;
        public int AttackRange;
        public float AttackRangeMul;
        public float AttackSpeed;
        public float MoveSpeed;
        public int Coin;
    }
}