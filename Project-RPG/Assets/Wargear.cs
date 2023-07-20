using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wargear
{
    public Armor armor;
    public Weapon weapon;

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
    }

    public void Dequip(WargearItem item)
    {
        InventoryManager.Instance.AddItem(item);
    }
}
