using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarsManager : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] Slider healthSlider;
    [SerializeField] TMP_Text healthText;

    [SerializeField] Slider manaSlider;
    [SerializeField] TMP_Text manaText;

    [SerializeField] Slider staminaSlider;
    [SerializeField] TMP_Text staminaText;

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
        healthText.text = $"{player.Health.CurrentValue}/{player.Health.maxValue.Value}";
    }
    private void UpdateManaSlider(int value)
    {
        manaSlider.value = value;
        manaText.text = $"{player.Mana.CurrentValue}/{player.Mana.maxValue.Value}";
    }
    private void UpdateStaminaSlider(int value)
    {
        staminaSlider.value = value;
        staminaText.text = $"{player.Stamina.CurrentValue}/{player.Stamina.maxValue.Value}";
    }
}
