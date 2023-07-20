using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new armor", menuName = "Items/Armor/new armor")]
public class Armor : WargearItem
{
    [Header("Armor")]
    public int defense;
}
