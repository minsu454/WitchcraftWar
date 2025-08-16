using Common.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IObjectPoolable<Projectile>
{
    public event Action<Projectile> ReturnEvent;

    private int damage;
    [SerializeField] private Rigidbody2D myRb;
    [SerializeField] private SpriteRenderer mySprRenderer;

    [SerializeField] private float moveSpeed;

    private void SetVelocity(Vector2 dir)
    {
        myRb.velocity = dir * moveSpeed;
    }

    public void Set(Color32 color, int damage)
    {
        mySprRenderer.color = color;
        this.damage = damage;

        SetVelocity(Vector2.down);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Enemy enemy = col.GetComponent<Enemy>();
            enemy.GetDamage(damage);
            gameObject.SetActive(false);
        }
        else if (col.CompareTag("ProjectileDetector"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        ReturnEvent.Invoke(this);
    }
}
