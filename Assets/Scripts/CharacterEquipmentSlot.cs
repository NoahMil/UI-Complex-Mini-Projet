using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterEquipmentSlot : MonoBehaviour, IDropHandler 
{
    public void OnDrop(PointerEventData eventData) 
    {
        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (inventoryItem != null)
        {
            Item item = inventoryItem.item;
            Debug.Log("Item dropped: " + item.itemType);
        }
    }
}