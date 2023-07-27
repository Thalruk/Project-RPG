using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ChangeableStat Health;

    private void Awake()
    {
        Health.CurrentValue = Health.maxValue.Value;
    }

    public virtual void TakeDamage(int damage)
    {
        Health.Decrease(damage);

        if(Health.CurrentValue == 0 )
        {
            Destroy(gameObject);
        }
    }
}
