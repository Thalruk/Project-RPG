using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ChangeableStat health;

    private void Awake()
    {
        health.CurrentValue = health.maxValue.Value;
    }

    public virtual void TakeDamage(int damage)
    {

        Debug.Log("is being attacked");
        health.Decrease(damage);

        if(health.CurrentValue == 0 )
        {
            Destroy(gameObject);
        }
    }
}
