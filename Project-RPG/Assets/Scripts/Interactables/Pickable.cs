using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{
    private void Awake()
    {
        message = "Press E to pick up";
    }

    public override void Interact()
    {
        InventoryManager.Instance.AddItem(GetComponent<ItemContainer>().item);
        InteractionManager.Instance.RemoveInteractable(this);

        Destroy(gameObject,0.1f);
    }
}
