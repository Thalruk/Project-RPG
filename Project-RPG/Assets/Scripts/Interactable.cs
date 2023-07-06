using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class Interactable : MonoBehaviour
{

    public string message;
    public virtual void Interact()
    {
        Debug.Log($"[{gameObject.name}]->{message}");
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
