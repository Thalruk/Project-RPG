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
            switch (modifier.type)
            {
                case StatModifierType.Flat:
                    finalValue += modifier.value;
                    break;
                case StatModifierType.Percent:
                    finalValue = Mathf.RoundToInt(finalValue * (1 + modifier.value/100f));
                    break;
                default:
                    break;
            }
        }
        Debug.Log($"{finalValue}");
        return finalValue;
    }

    public void AddModifier(StatModifier modifier)
    { 
        statModifiers.Add(modifier);
        Sort();
    }

    public bool RemoveModifier(StatModifier modifier)
    {
        bool result =  statModifiers.Remove(modifier);
        Sort();
        return result;
    }

    private void Sort()
    {
        statModifiers.Sort(SortMethod);
    }

    private int SortMethod(StatModifier firstMod, StatModifier secondMod)
    {
        return firstMod.type.CompareTo(secondMod.type);
    }
}
