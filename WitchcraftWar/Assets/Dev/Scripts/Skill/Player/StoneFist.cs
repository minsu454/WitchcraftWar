using System;
using UnityEngine;

public class StoneFist : Skill
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
