using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace INVENTORY
{
    public class CharacterEquipmentSlot : MonoBehaviour, IDropHandler
    {
        public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;
        public event EventHandler<OnItemRemovedEventArgs> OnItemRemoved;
    
        [SerializeField] private CharacterEquipmentManager.EquipSlot slotType;

        public class OnItemDroppedEventArgs : EventArgs
        {
            public Item item;
        }

        public class OnItemRemovedEventArgs : EventArgs
        {
            public Item item;
        }

        [SerializeField] private CharacterEquipmentManager _characterEquipmentManager;
        private Item _currentItem;

        public void OnDrop(PointerEventData eventData) 
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            if (inventoryItem != null && _characterEquipmentManager.TryItem(slotType, inventoryItem.item))
            {
                if (_currentItem != null)
                {
                    OnItemRemoved?.Invoke(this, new OnItemRemovedEventArgs() { item = _currentItem });
                }

                _currentItem = inventoryItem.item;
                inventoryItem.parentAfterDrag = transform;
                OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs() { item = _currentItem });
            }
        }

        public void ClearSlot()
        {
            if (_currentItem != null)
            {
                OnItemRemoved?.Invoke(this, new OnItemRemovedEventArgs() { item = _currentItem });
                _currentItem = null;
            }
        }
    }
}