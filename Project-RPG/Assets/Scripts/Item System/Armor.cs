using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New armor", menuName = "Items/new armor")]
public class Armor : Item
{
    [Header("Armor")]
    public int defense;
}
