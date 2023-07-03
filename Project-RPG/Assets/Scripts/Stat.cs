using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField] private int baseValue;
    public int Value 
    { 
        get
        { 
            return CalculateFinalValue();
        }
    }

    [SerializeField] public List<StatModifier> statModifiers;

    public Stat() 
    {
        baseValue = 0;
        statModifiers = new List<StatModifier>();
    }

    private int CalculateFinalValue()
    {
        int finalValue = baseValue;

        foreach (StatModifier modifier in statModifiers)
        {
            finalValue += modifier.value;
        }

        return finalValue;
    }
}
