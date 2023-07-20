using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wargear
{
    public Armor armor;
    public Weapon weapon;

    public List<ItemEffect> actualEffects;

    public void Equip(WargearItem item)
    {
        Debug.Log("equip " + item.name);
        if(item.GetType() == typeof(Armor)) 
        {
            if(armor != null)
            {
                Dequip(armor);
            }
            armor = (Armor)item;
        }

        if (item.GetType().BaseType == typeof(Weapon))
        {
            if (weapon != null)
            {
                Dequip(weapon);
            }
            weapon = (Weapon)item;
        }

        foreach (ItemEffect effect in item.Effects)
        {
            actualEffects.Add(effect);
        }
        ApplyEffects();
    }

    public void Dequip(WargearItem item)
    {
        InventoryManager.Instance.AddItem(item);
    }

    public void ApplyEffects()
    {
        foreach (ItemEffect effect in actualEffects)
        {
            switch (effect.affectedStat)
            {
                case AffectedStat.MaxHealth:
                    Player.Instance.Health.maxValue.AddModifier(effect.statModifier);
                    break;
                case AffectedStat.MaxMana:
                    Player.Instance.Mana.maxValue.AddModifier(effect.statModifier);
                    break;
                case AffectedStat.MaxStamina:
                    Player.Instance.Stamina.maxValue.AddModifier(effect.statModifier);
                    break;
                case AffectedStat.WalkingSpeed:
                    Player.Instance.WalkingSpeed.AddModifier(effect.statModifier);
                    break;
                case AffectedStat.RunningSpeed:
                    Player.Instance.RunningSpeed.AddModifier(effect.statModifier);
                    break;
                default:
                    break;
            }
        }
    }
}
