using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item item;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        Refresh();
    }
    public void Refresh()
    {
        if (item == null)
        {
            Debug.Log("there is no item");
            image.enabled = false;
        }
        else
        {
            Debug.Log("item");
            image.enabled = true;
            image.sprite = item.Sprite;
        }
    }
}
