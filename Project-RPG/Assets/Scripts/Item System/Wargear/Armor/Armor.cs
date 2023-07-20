using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ArmorType
{
    Leather,
    Iron
}

[CreateAssetMenu(fileName = "new armor", menuName = "Items/Armor/new armor")]
public class Armor : WargearItem
{
    [Header("Armor")]
    public ArmorType armorType;
    public int defense;
}
