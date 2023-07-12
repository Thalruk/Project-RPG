using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    public bool toggled = false;
    public void PauseGame()
    {
        toggled = !menuPanel.activeSelf;
        menuPanel.SetActive(toggled);
    }
    public void ExitGame()
    {
        Debug.Log("Exit application");
        Application.Quit();
    }
}
