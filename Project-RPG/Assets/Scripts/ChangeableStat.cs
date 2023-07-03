using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class ChangeableStat
{
    [SerializeField] public Stat maxValue;
    [SerializeField] public float currentValue;
    [SerializeField] public Stat regenValue;

    public void Increase(float value)
    {
        currentValue = Math.Clamp(currentValue + value, 0, maxValue.Value);
    }
    public void Decrease(float value)
    {
        currentValue = Math.Clamp(currentValue - value, 0, maxValue.Value);
    }
}
