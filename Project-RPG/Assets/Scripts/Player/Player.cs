using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [Header("Stats")]
    [SerializeField] public ChangeableStat Health;
    [SerializeField] public ChangeableStat Mana;
    [SerializeField] public ChangeableStat Stamina;

    [Space(10)]
    [Header("Bonus Stats")]
    [SerializeField] public Stat walkingSpeed;
    [SerializeField] public Stat runnigSpeed;
    [SerializeField] public Stat JumpStrength;
    [SerializeField] public Stat GravityMultiplier;

    [Space(10)]
    [Header("Inventory")]
    public Inventory inventory;


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
