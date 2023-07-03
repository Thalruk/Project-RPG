using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StatModifierType
{
    Flat,
    Percent,
}

[Serializable]
public class StatModifier
{
    [SerializeField] public int value;
    [SerializeField] public StatModifierType type;

    public StatModifier(int value, StatModifierType type)
    {
        this.value = value;
        this.type = type;
    }
}
