using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StatModifierType
{
    Flat,
}

[Serializable]
public class StatModifier
{
    [SerializeField] public int value;
    [SerializeField] private StatModifierType type;
}
