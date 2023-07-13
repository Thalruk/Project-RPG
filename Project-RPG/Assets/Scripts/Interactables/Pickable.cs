using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{
    public override void Interact()
    {
        InventoryManager.Instance.AddItem(GetComponent<ItemContainer>().item);
        InventoryManager.Instance.RefreshInventory();
        InteractionManager.Instance.RemoveInteractable(this);

        Destroy(gameObject,0.1f);
    }
}
