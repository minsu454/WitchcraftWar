using System;
using System.Collections.Generic;

public class Table
{
    [Serializable]
    public class ItemTable : ITable
    {
        public List<TableData.Item> Item;

        public IData FindID(object ID)
        {
            return Item.Find(item => (int)item.ID == (int)ID);
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
