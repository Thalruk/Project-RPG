using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    [SerializeField] private List<Item> items;

    public void Add(Item item)
    {
        items.Add(item);
    }

    public bool Remove(Item item)
    {
        return items.Remove(item);
    }
}
