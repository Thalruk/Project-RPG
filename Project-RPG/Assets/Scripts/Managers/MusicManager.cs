using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    private AudioSource musicSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;

        musicSource = GetComponent<AudioSource>();
    }
    public void ActivateMusic()
    {
        musicSource.Play();
    }

    public void DeactivateMusic()
    {
        musicSource.Stop();
    }
}
