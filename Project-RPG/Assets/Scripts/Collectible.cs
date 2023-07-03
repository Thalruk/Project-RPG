using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    StatModifier statModifier = new StatModifier(10, StatModifierType.Flat);
    AudioSource collectSound;

    private void Awake()
    {
        collectSound = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            collectSound.Play();
            Player.Instance.runningSpeed.AddModifier(statModifier);
            Player.Instance.walkingSpeed.AddModifier(statModifier);
            GetComponent<Collider>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(gameObject, 3);
        }
    }

}
