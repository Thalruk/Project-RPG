using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeState()
    {
        Debug.Log("AAAAAAA");
        isOpen = !isOpen;
        anim.SetTrigger("ChangeState");
    }
}
