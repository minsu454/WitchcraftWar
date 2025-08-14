using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement<Enemy>
{
    public override void Move()
    {
        Vector3 dirVec = (EntityManager.player.transform.position - transform.position).normalized;
        myRb.velocity = dirVec * entity.MoveSpeed;
    }

    public override void Stop()
    {
        myRb.velocity = Vector2.zero;
    }
}
