using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] Player player;

    public GameObject inventoryPanel;

    public bool toggled = false;

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
        RefreshInventory();

    }
    public void ToggleInventory()
    {
        toggled = !inventoryPanel.activeSelf;
        inventoryPanel.SetActive(toggled);
        Time.timeScale = toggled ? 0 : 1;
        RefreshInventory();
    }

    public void RefreshInventory()
    {
        inventorySlots = inventoryPanel.GetComponentsInChildren<InventorySlot>();

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
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (i < player.inventory.items.Count)
                {
                    inventorySlots[i].Item = player.inventory.items[i];
                }
                else
                {
                    inventorySlots[i].ResetState();
                }

                inventorySlots[i].Refresh();
            }
        }
    }


    public void AddItem(Item item)
    {
        player.inventory.Add(item);
    }

    public bool RemoveItem(Item item)
    {
        return player.inventory.Remove(item);
    }
}
