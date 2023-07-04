using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Droppable : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform rectTransform = transform as RectTransform;
        if(!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, eventData.position))
        {
            Debug.Log("DROP");
        }
    }
}
