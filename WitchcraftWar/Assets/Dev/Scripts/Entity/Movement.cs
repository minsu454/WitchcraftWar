using UnityEngine;

public abstract class Movement<T> : MonoBehaviour where T : Entity
{
    protected T entity;             //본체
    protected Rigidbody2D myRb;     //물리

    protected virtual void Awake()
    {
        entity = GetComponent<T>();
        myRb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Move();
    }



    /// <summary>
    /// 움직이는 함수
    /// </summary>
    public abstract void Move();

    /// <summary>
    /// 멈추는 함수
    /// </summary>
    public abstract void Stop();
}
