using System;
using System.Collections.Generic;

public class Table
{
    [Serializable]
    public class SkillTable : ITable
    {
        public List<TableData.Skill> Item;

        public IData FindID(object ID)
        {
            return Item.Find(skill => (int)skill.ID == (int)ID);
        }
    }

    [Serializable]
    public class MonsterTable : ITable
    {
        public List<TableData.Monster> Monster;

        public IData FindID(object ID)
        {
            return Monster.Find(item => (string)item.ID == (string)ID);
        }
    }
}
