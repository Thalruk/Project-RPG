using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private MenuManager menuManager;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;

        
    }
    public void ToggleInventory()
    {
        inventoryManager.ToggleInventory();
        ToggleTime();
    }
    public void ToggleMenu() 
    { 
        menuManager.ToggleMenu();
        ToggleTime();
    }

    void ToggleTime()
    {
        if(inventoryManager.toggled || menuManager.toggled)
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
