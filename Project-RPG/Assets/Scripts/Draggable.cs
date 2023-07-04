using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    Transform parentAfterDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(InventoryManager.Instance.inventoryPanel.transform);
        transform.SetAsLastSibling();
        eventData.pointerDrag.GetComponent<ItemSlot>().image.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        transform.localPosition = Vector3.zero;
        eventData.pointerDrag.GetComponent<ItemSlot>().image.raycastTarget = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform rectTransform = InventoryManager.Instance.inventoryPanel.transform as RectTransform;
        if (!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, eventData.pointerDrag.transform.position))
        {
            Debug.Log("DROPPED ITEM");
            //if (eventData.pointerDrag.GetComponent<ItemSlot>() != null)
            //{
            //    Debug.Log("DROP " + eventData.selectedObject.GetComponent<ItemSlot>().item);
            //}
        }
    }
}
