using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (transform.childCount != 0)
            {
                RectTransform draggedItemRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();

                draggedItemRectTransform.SetParent(transform);

                draggedItemRectTransform.localPosition = Vector3.zero;
            }
        }
    }
}