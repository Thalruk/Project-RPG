using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    OneHanded,
    TwoHanded
}
public class Weapon : WargearItem
{
    [Header("Weapon")]
    public int damage;
    public WeaponType weaponType;

}
