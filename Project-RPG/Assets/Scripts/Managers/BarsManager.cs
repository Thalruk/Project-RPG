using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarsManager : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] Slider healthSlider;
    [SerializeField] Slider manaSlider;
    [SerializeField] Slider staminaSlider;

    private void Awake()
    {
        healthSlider.maxValue = player.Health.maxValue.Value;
        healthSlider.value = player.Health.CurrentValue;
        player.Health.OnValueChanged.AddListener(UpdateHealthSlider);

        manaSlider.maxValue = player.Mana.maxValue.Value;
        manaSlider.value = player.Mana.CurrentValue;
        player.Mana.OnValueChanged.AddListener(UpdateManaSlider);

        staminaSlider.maxValue = player.Stamina.maxValue.Value;
        staminaSlider.value = player.Stamina.CurrentValue;
        player.Stamina.OnValueChanged.AddListener(UpdateStaminaSlider);
    }
    private void UpdateHealthSlider(int value)
    {
        healthSlider.value = value;
    }
    private void UpdateManaSlider(int value)
    {
        manaSlider.value = value;
    }
    private void UpdateStaminaSlider(int value)
    {
        staminaSlider.value = value;
    }
}
