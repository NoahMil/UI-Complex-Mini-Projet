using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterEquipmentSlot : MonoBehaviour, IDropHandler
{
    public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;

    public class OnItemDroppedEventArgs : EventArgs
    {
        public Item item;
    }

    public void OnDrop(PointerEventData eventData) 
    {
        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (inventoryItem != null)
        {
            inventoryItem.parentAfterDrag = transform;
            OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs() { item = inventoryItem.item });
        }
    }
}