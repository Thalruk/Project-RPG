using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] public ChangeableStat Health;
    [SerializeField] public ChangeableStat Mana;
    [SerializeField] public ChangeableStat Stamina;

    public void TakeDamage(int value)
    {
        Health.Decrease(value);
    }

    public void Heal(int value)
    {
        Health.Increase(value);
    }
}
