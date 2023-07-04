using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Droppable : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform rectTransform = transform as RectTransform;
        if(!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, eventData.pointerDrag.transform.position))
        {
            Debug.Log("DROPPED OUTSIDE");
            if(eventData.pointerDrag.GetComponent<ItemSlot>() != null)
            {
                Debug.Log("HERE IS NAME " + eventData.pointerDrag.GetComponent<ItemSlot>().item);
            }
        }
    }
}
