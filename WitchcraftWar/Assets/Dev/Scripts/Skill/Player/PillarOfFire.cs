using System;
using UnityEngine;

public class PillarOfFire : Skill
{
    public override void Reset()
    {

    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log($"{gameObject.name}");
    }
}
