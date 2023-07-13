using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Interactable : MonoBehaviour
{

    public string message;

    private void Awake()
    {
        message = "Press E to interact!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
    }
    public virtual void Interact()
    {
        Debug.Log($"[{gameObject.name}]->This should not show!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            InteractionManager.Instance.AddInteractable(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InteractionManager.Instance.RemoveInteractable(this);
        }
    }
}
