using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemSlot itemSlot;
    void Awake()
    {
        Refresh();
    }

    public void Refresh()
    {
        itemSlot.Refresh();
    }
}
