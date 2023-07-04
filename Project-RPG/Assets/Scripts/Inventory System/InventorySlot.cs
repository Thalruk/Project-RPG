using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    GameObject itemSpriteSlot;
    void Awake()
    {
        itemSpriteSlot = transform.GetChild(0).gameObject;
        Refresh();
    }

    public void Refresh()
    {
        if (item == null)
        {
            Debug.Log("there is no item");
            itemSpriteSlot.SetActive(false);
        }
        else
        {
            Debug.Log("item");
            itemSpriteSlot.SetActive(true);
            itemSpriteSlot.GetComponent<Image>().sprite = item.Sprite;
        }
    }
}
