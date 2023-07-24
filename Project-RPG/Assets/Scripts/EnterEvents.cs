using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterEvents : MonoBehaviour
{
    public UnityEvent events;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("EVENTS");
            events.Invoke();
        }
    }
}