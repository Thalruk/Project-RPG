using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AffectedStat
{
    MaxHealth,
    MaxMana,
    MaxStamina,
    WalkingSpeed,
    RunningSpeed
}
[Serializable]
public class ItemEffect
{
    public AffectedStat affectedStat;
    public StatModifier statModifier;
}
