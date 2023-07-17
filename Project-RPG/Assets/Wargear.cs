using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wargear
{
    public Helm helm;

    public void Equip(Item item)
    {
        Debug.Log("equip " + item.name);
    }
}
