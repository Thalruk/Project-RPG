using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    public bool toggled = false;
    public void ToggleMenu()
    {
        toggled = !menuPanel.activeSelf;
        menuPanel.SetActive(toggled);
        Time.timeScale = toggled ? 0 : 1;
    }
}
