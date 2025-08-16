using System;
using UnityEngine;

public class Charcoal : Skill
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
