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
    public InventorySlot weaponSlot;
    public InventorySlot armorSlot;

    [Header("Player graphics")]
    public GameObject arms;
    public GameObject legs;
    public GameObject feet;
    public GameObject leatherArmor;
    public GameObject ironArmor;

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
        weaponSlot.Item = wargear.weapon;
        weaponSlot.Refresh();
        armorSlot.Item = wargear.armor;
        armorSlot.Refresh();
    }

    public void RefreshSkin()
    {
        if(wargear.armor == null) 
        {
            arms.SetActive(true);
            legs.SetActive(true);
            feet.SetActive(true);
        }
        else
        {
            switch (wargear.armor.armorType)
            {
                case ArmorType.Leather:
                    arms.SetActive(false);
                    legs.SetActive(false);
                    feet.SetActive(false);
                    leatherArmor.SetActive(true);
                    ironArmor.SetActive(false);
                    break;
                case ArmorType.Iron:
                    arms.SetActive(false);
                    legs.SetActive(false);
                    feet.SetActive(false);
                    leatherArmor.SetActive(false);
                    ironArmor.SetActive(true);
                    break;
            }
        }
    }


    public void Equip(WargearItem item)
    {
        wargear.Equip(item);
        RefreshSkin();
        if(toggled)
        {
            RefreshWargear();
        }
    }

    public void Dequip(WargearItem item)
    {
        wargear.Dequip(item);
        RefreshSkin();
        if (toggled)
        {
            RefreshWargear();
        }
    }
}
