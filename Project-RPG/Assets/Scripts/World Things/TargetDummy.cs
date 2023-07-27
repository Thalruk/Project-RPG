using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetDummy : Target
{
    Animator anim;
    [SerializeField] Slider healthSlider;
    [SerializeField] Image healthSliderFill;

    [SerializeField] Vector3 healtSliderOffset;

    private void Awake()
    {
        Health.CurrentValue = Health.maxValue.Value;
        anim = GetComponent<Animator>();

        healthSlider.maxValue = Health.maxValue.Value;
        healthSlider.value = Health.CurrentValue;
    }

    private void Update()
    {
        healthSlider.transform.rotation = Camera.main.transform.rotation;
        healthSlider.transform.position = transform.position + healtSliderOffset;
    }
    public override void TakeDamage(int damage)
    {
        anim.SetTrigger("Attacked");
        Health.Decrease(damage);

        UpdateHealtSlider();

        if (Health.CurrentValue == 0)
        {
            anim.SetTrigger("Died");
        }
    }

    private void UpdateHealtSlider()
    {
        healthSlider.value = Health.CurrentValue;
        healthSliderFill.color = Color.Lerp(Color.red, Color.black, (Health.maxValue.Value - Health.CurrentValue) / (float)Health.maxValue.Value);
        Debug.Log((Health.maxValue.Value - Health.CurrentValue) / (float)Health.maxValue.Value);
    }

    public void OnDeath()
    {
        healthSlider.gameObject.SetActive(false);
    }
}
