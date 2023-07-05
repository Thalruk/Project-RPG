using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private ItemSlot itemSlot;
    public Item Item
    {
        get
        {
            return itemSlot.item;
        }
        set
        {
            itemSlot.item = value;
        }
    }
    void Awake()
    {
        itemSlot = GetComponentInChildren<ItemSlot>();
    }

    public void Refresh()
    {
        itemSlot.Refresh();
    }

    public void ResetState()
    {
        itemSlot.ResetState();
    }
}
