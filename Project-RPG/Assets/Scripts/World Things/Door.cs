using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    Animator anim;
    AudioSource source;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    public void ChangeState()
    {
        Debug.Log("AAAAAAA");
        isOpen = !isOpen;
        source.Play();
        anim.SetTrigger("ChangeState");
    }
}
