using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudioEvent : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] GameObject objectToDestroy;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        audioSource.Play();
    }

    public void OnDie()
    {
        Destroy(objectToDestroy);
    }
}
