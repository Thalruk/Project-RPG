using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public static Player Instance;

    [Space(10)]
    [Header("Bonus Stats")]
    [SerializeField] public Stat WalkingSpeed;
    [SerializeField] public Stat RunningSpeed;
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

    public override void TakeDamage(int value)
    {
        base.TakeDamage(value);

        if(Health.CurrentValue == 0)
        {
            MenuManager.Instance.ResetPosition();
        }
    }
}
