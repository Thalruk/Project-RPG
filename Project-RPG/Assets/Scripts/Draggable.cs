using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform parentAfterDrag;
    public Transform trans;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
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

        RectTransform rectTransform = InventoryManager.Instance.inventoryPanel.transform as RectTransform;
        if (!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, eventData.position))
        {
            Debug.Log("DROPPED OUTSIDE");
            if (eventData.pointerDrag.GetComponent<ItemSlot>() != null)
            {
                Debug.Log("there is even an item");
            }
        }

        eventData.pointerDrag.GetComponent<ItemSlot>().image.raycastTarget = true;
    }
}
