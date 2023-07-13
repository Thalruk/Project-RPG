using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteractable : Interactable
{
    private void Awake()
    {
        message = "Press E to open";
    }

    public override void Interact()
    {
        Debug.Log("container");
    }
}
