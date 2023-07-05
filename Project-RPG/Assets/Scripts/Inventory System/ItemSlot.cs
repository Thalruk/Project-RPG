using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item item;
    public Image image;
    public Image Background;

    [SerializeField] private Sprite commonBackground;
    [SerializeField] private Sprite uncommonBackground;
    [SerializeField] private Sprite rareBackground;
    [SerializeField] private Sprite legendaryBackground;
    [SerializeField] private Sprite magicalBackground;
    [SerializeField] private Sprite angelicBackground;
    [SerializeField] private Sprite demonicBackground;

    private void Awake()
    {
        Refresh();
    }
    public void Refresh()
    {
        if (item == null)
        {
            image.enabled = false;
            Background.sprite = null;
        }
        else
        {
            switch (item.Rarity)
            {
                case Rarity.Common:
                    Background.sprite = commonBackground;
                    break;
                case Rarity.Uncommon:
                    Background.sprite = uncommonBackground;
                    break;
                case Rarity.Rare:
                    Background.sprite = rareBackground;
                    break;
                case Rarity.Legendary:
                    Background.sprite = legendaryBackground;
                    break;
                case Rarity.Magical:
                    Background.sprite = magicalBackground;
                    break;
                case Rarity.Angelic:
                    Background.sprite = angelicBackground;
                    break;
                case Rarity.Demonic:
                    Background.sprite = demonicBackground;
                    break;
                default:
                    break;
            }
            image.enabled = true;
            image.sprite = item.Sprite;
        }
    }
    public void ResetState()
    {
        item = null;
        Refresh();
    }
}
