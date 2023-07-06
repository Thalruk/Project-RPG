using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Pickable : Interactable
{
    public override void Interact()
    {
        InventoryManager.Instance.AddItem(GetComponent<ItemContainer>().item);
        InventoryManager.Instance.RefreshInventory();
        Destroy(gameObject);
    }
}
