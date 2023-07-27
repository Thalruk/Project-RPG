using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Item item;
    public Image image;
    public Image Background;

    public bool wargearSlot = false;

    [SerializeField] private Sprite commonBackground;
    [SerializeField] private Sprite uncommonBackground;
    [SerializeField] private Sprite rareBackground;
    [SerializeField] private Sprite legendaryBackground;
    [SerializeField] private Sprite magicalBackground;
    [SerializeField] private Sprite angelicBackground;
    [SerializeField] private Sprite demonicBackground;

    Transform parentAfterDrag;
    public Transform trans;

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
            Background.sprite = item.Rarity switch
            {
                Rarity.Common => commonBackground,
                Rarity.Uncommon => uncommonBackground,
                Rarity.Rare => rareBackground,
                Rarity.Legendary => legendaryBackground,
                Rarity.Magical => magicalBackground,
                Rarity.Angelic => angelicBackground,
                Rarity.Demonic => demonicBackground,
                _ => null
            };

            image.enabled = true;
            image.sprite = item.Sprite;
        }
    }
    public void ResetState()
    {
        item = null;
        Refresh();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (wargearSlot)
            {
                WargearManager.Instance.Dequip((WargearItem)item);
            }
            else
            {
                item.Use();
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            eventData.pointerDrag.GetComponent<ItemSlot>().image.raycastTarget = false;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            transform.position = eventData.position;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            transform.SetParent(parentAfterDrag);
            transform.localPosition = Vector3.zero;

            RectTransform rectTransform = InventoryManager.Instance.inventoryPanel.transform as RectTransform;
            if (!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, eventData.position))
            {
                Debug.Log("there is even an item");
                Debug.Log("DROPPED OUTSIDE");
                if (eventData.pointerDrag.TryGetComponent(out ItemSlot slot))
                {
                    Debug.Log("there is even an item");
                    ItemContainer container = Instantiate(WorldSettings.Instance.itemContainer, Player.Instance.transform.position + PlayerMovement.Instance.cameraDirection.normalized * 2, Quaternion.identity).GetComponent<ItemContainer>();
                    container.item = slot.item;
                    container.UpdateMesh();
                    InventoryManager.Instance.RemoveItem(slot.item);
                }
            }

            eventData.pointerDrag.GetComponent<ItemSlot>().image.raycastTarget = true;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (eventData.pointerDrag.TryGetComponent(out ItemSlot slot))
            {
                Debug.Log($"droppe on {slot.item.name}");
                Debug.Log($"dropped {GetComponent<ItemSlot>().item?.name}");
            }
        }
    }
}

