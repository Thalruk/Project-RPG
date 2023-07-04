using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] Player player;

    public GameObject inventoryPanel;

    public GameObject inventorySlotPanel;
    private InventorySlot[] inventorySlots;
    public GameObject inventorySlot;

    public int rowSlotNumber;

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
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        RefreshInventory();
    }

    public void RefreshInventory()
    {
        inventorySlots = inventoryPanel.GetComponentsInChildren<InventorySlot>();
        Debug.Log((int)((player.inventory.items.Count + 1) % rowSlotNumber));
        if ((int)((player.inventory.items.Count + 1) % rowSlotNumber) == 0)
        {
            Debug.Log("CRERATE SLOTS");
            for (int i = 0; i < rowSlotNumber; i++)
            {
                Instantiate(inventorySlot, inventorySlotPanel.transform);
            }
        }
        if (inventoryPanel.activeSelf)
        {
            for (int i = 0; i < player.inventory.items.Count; i++)
            {
                inventorySlots[i].Item = player.inventory.items[i];
                inventorySlots[i].Refresh();
            }
        }
    }
}
