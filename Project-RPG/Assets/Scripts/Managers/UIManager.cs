using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private InventoryManager inventoryManager;
    private MenuManager menuManager;
    private WargearManager wargearManager;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;

        inventoryManager = InventoryManager.Instance;
        menuManager = MenuManager.Instance;
        wargearManager = WargearManager.Instance;
    }

    public void ToggleMenu()
    {
        if (inventoryManager.toggled)
        {
            ToggleInventory();
        }
        else if (wargearManager.toggled)
        {
            ToggleWargear();
        }
        else
        {
            menuManager.ToggleMenu();
            ToggleTime();
        }
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
            wargearManager.ToggleWargear();
            ToggleTime();
        }
    }

    void ToggleTime()
    {
        if (inventoryManager.toggled || menuManager.toggled || wargearManager.toggled)
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
