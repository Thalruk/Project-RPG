using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] GameObject inventory;
    [SerializeField] Player player;
    public GameObject inventorySlot;

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
        inventory.SetActive(!inventory.activeSelf);
    }

    public void RefreshInventory()
    {
        for (int i = 0; i < player.inventory.items.Count; i++)
        {
        }
    }
}
