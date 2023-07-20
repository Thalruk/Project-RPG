using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] private GameObject menuPanel;

    public GameObject player;
    public bool toggled = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    public void ResetPosition()
    {
        SceneManager.LoadScene("PlayerScene", LoadSceneMode.Single);
    }

    public void ToggleMenu()
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
