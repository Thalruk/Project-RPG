using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class Interactable : MonoBehaviour
{
    public Item item;

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    public virtual void Interact()
    {
        Debug.Log($"Interacted with {gameObject.name}");
    }

}
