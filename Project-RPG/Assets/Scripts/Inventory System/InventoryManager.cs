using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public GameObject inventoryPanel;
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
    }
    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        RefreshInventory();
    }

    public void RefreshInventory()
    {
        if(inventoryPanel.activeSelf)
        {
            for (int i = 0; i < player.inventory.items.Count; i++)
            {
                inventorySlots[i].Item = player.inventory.items[i];
                inventorySlots[i].Refresh();
            }
        }
    }

}
