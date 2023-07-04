using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] Slider healthSlider;
    [SerializeField] Slider manaSlider;
    [SerializeField] Slider staminaSlider;

    private void Awake()
    {
        healthSlider.maxValue = player.health.maxValue.Value;
        healthSlider.value = player.health.CurrentValue;
        player.health.OnValueChanged.AddListener(UpdateHealthSlider);

        manaSlider.maxValue = player.mana.maxValue.Value;
        manaSlider.value = player.mana.CurrentValue;
        player.mana.OnValueChanged.AddListener(UpdateManaSlider);

        staminaSlider.maxValue = player.stamina.maxValue.Value;
        staminaSlider.value = player.stamina.CurrentValue;
        player.stamina.OnValueChanged.AddListener(UpdateStaminaSlider);
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
