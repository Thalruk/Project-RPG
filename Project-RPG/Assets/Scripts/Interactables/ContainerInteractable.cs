using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteractable : Interactable
{
    public GameObject itemContainer;
    public List<Item> Items;
    private void Awake()
    {
        message = "Press E to open";
    }

    public override void Interact()
    {
        foreach (Item item in Items)
        {
            Debug.Log(item.name);

        }
        Debug.Log("container");
    }
}
