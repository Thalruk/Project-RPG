using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [Header("Stats")]
    public ChangeableStat health;
    [SerializeField] public ChangeableStat mana;
    [SerializeField] public ChangeableStat stamina;

    [Space(10)]
    [Header("Bonus Stats")]
    [SerializeField] public Stat walkingSpeed;
    [SerializeField] public Stat runningSpeed;

    public Inventory inventory;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;

        StartCoroutine(health.Regenerate());
        StartCoroutine(mana.Regenerate());
        StartCoroutine(stamina.Regenerate());
    }
}
