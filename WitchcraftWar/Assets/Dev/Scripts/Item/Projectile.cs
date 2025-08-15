using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IObjectPoolable<Projectile>
{
    public event Action<Projectile> ReturnEvent;

    [SerializeField] private int damage;
    [SerializeField] private Rigidbody2D myRb;

    [SerializeField] private float moveSpeed;

    public void SetVelocity(Vector3 dir)
    {
        myRb.velocity = dir * moveSpeed;
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
