using Common.Yield;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 트리거 콜라이더가 다른곳에 있을 때 사용하는 클래스
/// </summary>
public class TriggerDetector2D : MonoBehaviour
{
    /// <summary>
    /// Trigger Enter시 사용 이벤트
    /// </summary>
    public event Action<Collider2D> EnterEvent;

    /// <summary>
    /// Trigger Exit시 사용 이벤트
    /// </summary>
    public event Action<Collider2D> ExitEvent;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        EnterEvent?.Invoke(collider);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        ExitEvent?.Invoke(collider);
    }
}