using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetDummy : Target
{
    Animator anim;
    [SerializeField] Slider healthSlider;
    [SerializeField] Vector3 healtSliderOffset;

    private void Awake()
    {
        health.CurrentValue = health.maxValue.Value;
        anim = GetComponent<Animator>();

        healthSlider.maxValue = health.maxValue.Value;
        healthSlider.value = health.CurrentValue;
    }

    private void Update()
    {
        healthSlider.transform.rotation = Camera.main.transform.rotation;
        healthSlider.transform.position = transform.position + healtSliderOffset;
    }
    public override void OnHit(int damage)
    {
        anim.SetTrigger("Attacked");
        health.Decrease(damage);

        UpdateHealtSlider();

        if (health.CurrentValue == 0)
        {
            Debug.Log("DEAD");
            anim.SetTrigger("Died");
        }
    }

    private void UpdateHealtSlider()
    {
        healthSlider.value = health.CurrentValue;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
