using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] public ChangeableStat Health;
    [SerializeField] public ChangeableStat Mana;
    [SerializeField] public ChangeableStat Stamina;

    public virtual void TakeDamage(int value)
    {
        Health.Decrease(value);
    }

    public virtual void Heal(int value)
    {
        Health.Increase(value);
    }
}
