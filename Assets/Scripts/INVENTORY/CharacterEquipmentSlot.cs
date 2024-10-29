using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace INVENTORY
{
    public class CharacterEquipmentSlot : MonoBehaviour, IDropHandler
    {
        public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;
    
        [SerializeField] private CharacterEquipmentManager.EquipSlot slotType;

        public class OnItemDroppedEventArgs : EventArgs
        {
            public Item item;
        }

        [SerializeField] private CharacterEquipmentManager _characterEquipmentManager;
    
        public void OnDrop(PointerEventData eventData) 
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            if (inventoryItem != null && _characterEquipmentManager.TryItem(slotType, inventoryItem.item))
            {
                inventoryItem.parentAfterDrag = transform;
                OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs() { item = inventoryItem.item });
            }
        }
    }
}