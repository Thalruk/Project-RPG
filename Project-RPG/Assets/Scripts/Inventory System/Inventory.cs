using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Inventory
{
#nullable enable
    [SerializeField] public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        items.Add(item);
    }

    public bool Remove(Item item)
    {
        return items.Remove(item);
    }
}
