using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] Player player;
    private InventorySlot[] inventorySlots;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
        inventorySlots = inventoryPanel.GetComponentsInChildren<InventorySlot>();
        ToggleInventory();
        RefreshInventory();
    }
    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    public void RefreshInventory()
    {
        for (int i = 0; i < player.inventory.items.Count; i++)
        {
            inventorySlots[i].item = player.inventory.items[i];
            inventorySlots[i].Refresh();
        }
    }
}
