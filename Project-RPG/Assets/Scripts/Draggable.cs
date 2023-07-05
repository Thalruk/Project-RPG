using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    Transform parentAfterDrag;
    [SerializeField] GameObject itemContainer;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Use");
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
                Debug.Log("DROPPED OUTSIDE");
                if (eventData.pointerDrag.TryGetComponent(out ItemSlot slot))
                {
                    Debug.Log("there is even an item");
                    GameObject container = Instantiate(itemContainer, Player.Instance.transform.position + new Vector3(0, 1, 2), Quaternion.identity);
                    container.GetComponent<ItemContainer>().item = slot.item;
                    InventoryManager.Instance.RemoveItem(slot.item);
                    InventoryManager.Instance.RefreshInventory();
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
