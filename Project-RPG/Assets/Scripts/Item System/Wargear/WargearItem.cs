using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WargearItem : Item
{

    public List<ItemEffect> Effects = new List<ItemEffect>();
    public override void Use()
    {
        Debug.Log("EQIP FROM WARGEARITEM");
        WargearManager.Instance.Equip(this);
        InventoryManager.Instance.RemoveItem(this);
    }
}
