using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new weapon", menuName = "Items/new weapon")]
public class Weapon : Item
{
    [Header("Weapon")]
    public int damage;
}
