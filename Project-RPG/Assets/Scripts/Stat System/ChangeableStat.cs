using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ChangeableStat
{
    [SerializeField] public Stat maxValue;
    [SerializeField] private int currentValue;
    [SerializeField] public Stat regenValue;
    [HideInInspector] public UnityEvent<int> OnValueChanged;

    public int CurrentValue
    {
        get 
        { 
            return currentValue;
        }
        set
        {
            currentValue = value;
            OnValueChanged?.Invoke(currentValue);
            Debug.Log("invoked");
        }
    }

    public void Increase(int value)
    {
        CurrentValue = Math.Clamp(currentValue + value, 0, maxValue.Value);
    }
    public void Decrease(int value)
    {
        CurrentValue = Math.Clamp(currentValue - value, 0, maxValue.Value);
    }

    public IEnumerator Regenerate()
    {
        while (true)
        {
            Increase(regenValue.Value);
            yield return new WaitForSeconds(1);
        }
    }
}
