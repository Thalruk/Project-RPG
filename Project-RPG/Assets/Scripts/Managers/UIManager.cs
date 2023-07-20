using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private WargearManager wargearManager;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;


    }
  
    public void ToggleMenu()
    {
        if (inventoryManager.toggled)
        {
            ToggleInventory();
        }

        if (wargearManager.toggled)
        {
            ToggleWargear();
        }

        menuManager.ToggleMenu();
        ToggleTime();
    }

    public void ToggleInventory()
    {
        if (!menuManager.toggled)
        {
            inventoryManager.ToggleInventory();
            ToggleTime();
        }
    }

    public void ToggleWargear()
    {
        if (!menuManager.toggled)
        {
            inventoryManager.ToggleInventory();
            ToggleTime();
        }
    }

    void ToggleTime()
    {
        if (inventoryManager.toggled || menuManager.toggled)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
        }
    }
}
