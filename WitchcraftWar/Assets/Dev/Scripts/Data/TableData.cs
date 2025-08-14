using System;

public class TableData
{
    [Serializable]
    public class Item : IData
    {
        public object ID { get { return ItemID; } }

        public int ItemID;
        public string Name;
        public string Description;
        public int UnlockLev;
        public int MaxHP;
        public float MaxHPMul;
        public int MaxMP;
        public float MaxMPMul;
        public int MaxAtk;
        public float MaxAtkMul;
        public int MaxDef;
        public float MaxDefMul;
        public int Status;
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
        public int MinExp;
        public int MaxExp;
        public int[] DropItem;
    }
}