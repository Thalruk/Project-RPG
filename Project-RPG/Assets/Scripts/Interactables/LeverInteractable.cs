using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class LeverInteractable : Interactable
{
    Animator anim;
    public UnityEvent onStateChanged;
    [SerializeField] bool isSecret = false;
    private void Awake()
    {
        if(isSecret == false)
        {
            message = "Press E to push the lever";
        }
        anim = GetComponent<Animator>();
    }
    public override void Interact()
    {
        anim.SetTrigger("Interact");
        onStateChanged.Invoke();
    }
}
