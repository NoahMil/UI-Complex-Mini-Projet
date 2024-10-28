using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterEquipmentSlot : MonoBehaviour, IDropHandler
{
    public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;
    
    [SerializeField] private CharacterEquipmentManager.EquipSlot slotType;

    public class OnItemDroppedEventArgs : EventArgs
    {
        public Item item;
    }

    [SerializeField] private CharacterEquipmentManager _characterEquipmentManage;
    
    public void OnDrop(PointerEventData eventData) 
    {
        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (inventoryItem != null && _characterEquipmentManage.TryItem(slotType, inventoryItem.item))
        {
            inventoryItem.parentAfterDrag = transform;
            OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs() { item = inventoryItem.item });
        }
    }
}