using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverInteractable : Interactable
{
    Animator anim;
    public UnityEvent onStateChanged;
    private void Awake()
    {
        message = "Press E to push the lever";
        anim = GetComponent<Animator>();
    }
    public override void Interact()
    {
        anim.SetTrigger("Interact");
        onStateChanged.Invoke();
    }
}
