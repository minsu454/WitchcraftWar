using System;
using System.Collections.Generic;
using UnityEngine;

public static class DataServices
{
    private readonly static Dictionary<Type, ITable> dataDict = new Dictionary<Type, ITable>();

    private const string path = "Data";

    /// <summary>
    /// 초기화
    /// </summary>
    public static void Init()
    {
        LoadData<Table.ItemTable>($"{path}/Item");
        LoadData<Table.MonsterTable>($"{path}/Monster");
    }

    /// <summary>
    /// 데이터 불러오는 함수
    /// </summary>
    private static void LoadData<T>(string path) where T : ITable
    {
        TextAsset json = Resources.Load<TextAsset>(path);
        T t = JsonUtility.FromJson<T>(json.text);

        dataDict.Add(typeof(T), t);
    }

    /// <summary>
    /// 아이템 데이터 받는 함수
    /// </summary>
    public static U GetData<T, U>(object id) where T : ITable where U : IData
    {
        if (!dataDict.TryGetValue(typeof(T), out ITable table))
        {
            Debug.LogError($"GetData Error : No Data { typeof(T).ToString()} , id : {id}");
            return default(U);
        }

        return (U)table.FindID(id);
    }
}
