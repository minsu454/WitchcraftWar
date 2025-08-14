using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IObjectPoolable<Item>
{
    public event Action<Item> ReturnEvent;              //ObjectPool리턴 이벤트 변수

    [SerializeField] private Animator animator;         //애니메이터
    private TableData.Item data;                        //아이템 데이터

    /// <summary>
    /// 아이템 세팅 함수
    /// </summary>
    public void Set(int itemId)
    {
        data = DataServices.GetData<Table.ItemTable, TableData.Item>(itemId);
        animator.runtimeAnimatorController = Managers.Container.ReturnAnimator((ItemIDType)itemId);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Player player = col.GetComponent<Player>();
            player.UseItem(data);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        ReturnEvent.Invoke(this);
    }
}
