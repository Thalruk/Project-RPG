using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [Space(10)]
    [Header("Inventory")]
    public Inventory inventory;

    public GameObject inventoryPanel;

    public bool toggled = false;

    [SerializeField] private GameObject inventorySlotPanel;
    private InventorySlot[] inventorySlots;
    [SerializeField] private GameObject inventorySlot;

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
        RefreshInventory();
    }

    public void RefreshInventory()
    {
        inventorySlots = inventoryPanel.GetComponentsInChildren<InventorySlot>();

        if ((int)((inventory.items.Count + 1) % rowSlotNumber) == 0)
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
                if (i < inventory.items.Count)
                {
                    inventorySlots[i].Item = inventory.items[i];
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
        Debug.Log("add");
        inventory.Add(item);
        RefreshInventory();
    }

    public bool RemoveItem(Item item)
    {
        bool removed = inventory.Remove(item);
        RefreshInventory();
        return removed;
    }
}
