using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public StatModifier statModifier = new StatModifier(10, StatModifierType.Flat);
    public float buffTime = 5;
    AudioSource collectSound;

    private void Awake()
    {
        collectSound = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            collectSound.Play();

            GetComponentInParent<Spawner>().SpawnAfterTime();

            Player.Instance.WalkingSpeed.AddModifier(statModifier);
            Player.Instance.RunningSpeed.AddModifier(statModifier);

            GetComponent<Collider>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);

            Destroy(gameObject, buffTime);
        }
    }

    private void OnDestroy()
    {
        Player.Instance.WalkingSpeed.RemoveModifier(statModifier);
        Player.Instance.RunningSpeed.RemoveModifier(statModifier);

    }
}
