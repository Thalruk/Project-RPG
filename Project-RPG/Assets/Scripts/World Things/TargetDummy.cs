using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : Target
{
    Animator anim;
    private void Awake()
    {
        health.CurrentValue = health.maxValue.Value;
        anim = GetComponent<Animator>();
    }
    public override void TakeDamage(int damage)
    {
        anim.SetTrigger("Attacked");
        base.TakeDamage(damage);
        
    }
}
