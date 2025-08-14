using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;

public class UIScrollViewButton : MonoBehaviour
{
    private object key;                                 //키
    [SerializeField] private TextMeshProUGUI mainText;  //메인 텍스트
    public event Action<object> OnClickEvent;           //클릭시 이벤트
        
    /// <summary>
    /// 초기화 함수
    /// </summary>
    public void Init(object key)
    {
        this.key = key;
        mainText.text = key.ToString();
    }

    /// <summary>
    /// 버튼 입력시 이벤트
    /// </summary>
    public void OnButton()
    {
        OnClickEvent?.Invoke(key);
    }
}
