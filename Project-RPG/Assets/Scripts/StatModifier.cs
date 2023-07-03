using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StatModifierType
{
    Flat,
    PecentageAdditive,
}

[Serializable]
public class StatModifier
{
    [SerializeField] public int value;
    [SerializeField] private StatModifierType type;

    public StatModifier(int value, StatModifierType type)
    {
        this.value = value;
        this.type = type;
    }
}
