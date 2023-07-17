using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public static Player Instance;


    [Space(10)]
    [Header("Bonus Stats")]
    [SerializeField] public Stat walkingSpeed;
    [SerializeField] public Stat runnigSpeed;
    [SerializeField] public Stat JumpStrength;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;

        StartCoroutine(Health.Regenerate());
        StartCoroutine(Mana.Regenerate());
        StartCoroutine(Stamina.Regenerate());
    }
}
