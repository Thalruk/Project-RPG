using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WargearManager : MonoBehaviour
{
    public static WargearManager Instance;

    [Space(10)]
    [Header("Wargear")]
    public Wargear wargear;

    public bool toggled = false;

    [Header("WargerUI")]
    public GameObject wargearPanel;
    public GameObject armorSlot;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }



    public void ToggleWargear()
    {
        toggled = !wargearPanel.activeSelf;
        wargearPanel.SetActive(toggled);
        RefreshWargear();
    }

    public void RefreshWargear()
    {
        Debug.Log("refresh wargear panel");
        armorSlot.GetComponent<InventorySlot>().Item = wargear.armor;
        armorSlot.GetComponent<InventorySlot>().Refresh();
    }


    public void Equip(WargearItem item)
    {
        wargear.Equip(item);
        RefreshWargear();
    }
}
