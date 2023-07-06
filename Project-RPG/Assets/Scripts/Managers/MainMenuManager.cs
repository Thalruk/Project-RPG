using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("PlayerScene", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Debug.Log("Exit application");
        Application.Quit();
    }
}
