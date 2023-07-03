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
        manaSlider.maxValue = player.mana.maxValue.Value;
        staminaSlider.maxValue = player.stamina.maxValue.Value;
    }
    private void Update()
    {
        healthSlider.value = player.health.currentValue;
        manaSlider.value = player.mana.currentValue;
        staminaSlider.value = player.stamina.currentValue;
    }
}
