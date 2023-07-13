using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    public GameObject player;
    public bool toggled = false;

    public void ResetPosition()
    {
        player.GetComponent<CharacterController>().transform.position = Vector3.zero;
        Debug.Log("reset");
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
