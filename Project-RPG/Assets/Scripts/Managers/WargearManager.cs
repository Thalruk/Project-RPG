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

    [Header("Player armor")]
    public GameObject arms;
    public GameObject legs;
    public GameObject feet;
    public GameObject leatherArmor;
    public GameObject ironArmor;

    [Header("Player weapon")]
    public GameObject axe;
    public GameObject sword;
    public GameObject greatsword;

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

    public void RefreshArmor()
    {
        if (wargear.armor == null)
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

    public void RefreshWeapon()
    {
        if (wargear.weapon == null)
        {
            axe.SetActive(false);
            sword.SetActive(false);
            greatsword.SetActive(false);
        }
        else
        {
            if (wargear.weapon.GetType() == typeof(Axe))
            {
                axe.SetActive(true);
                sword.SetActive(false);
                greatsword.SetActive(false);
            }
            else if (wargear.weapon.GetType() == typeof(Sword))
            {
                axe.SetActive(false);
                sword.SetActive(true);
                greatsword.SetActive(false);
            }
            else if(wargear.weapon.GetType() == typeof(Greatsword))
            {
                axe.SetActive(false);
                sword.SetActive(false);
                greatsword.SetActive(true);
            }
        }
    }


    public void Equip(WargearItem item)
    {
        wargear.Equip(item);
        RefreshArmor();
        RefreshWeapon();
        if (toggled)
        {
            RefreshWargear();
        }
    }

    public void Dequip(WargearItem item)
    {
        wargear.Dequip(item);
        RefreshArmor();
        RefreshWeapon();
        if (toggled)
        {
            RefreshWargear();
        }
    }
}
