using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "ScriptableObject/Item")]
public class Item : ScriptableObject
{
    public ItemType itemType;
    public Sprite image;
    
    public CharacterEquipmentManager.EquipSlot GetEquipSlot()
    { 
        switch (itemType) {
        default:
            case ItemType.PickAxe:
            case ItemType.Hammer:
                return CharacterEquipmentManager.EquipSlot.Weapon;
        case ItemType.Scarf:
            return CharacterEquipmentManager.EquipSlot.Scarf;
        case ItemType.Ring:
            return CharacterEquipmentManager.EquipSlot.Ring;
        case ItemType.Headband:
            return CharacterEquipmentManager.EquipSlot.Headband;
        case ItemType.Cloak:
            return CharacterEquipmentManager.EquipSlot.Cloak;
        case ItemType.Bracelet:
            return CharacterEquipmentManager.EquipSlot.Bracelet;
        } 
    }
}

public enum ItemType
{
    PickAxe,
    Hammer,
    Scarf,
    Ring,
    Headband,
    Cloak,
    Bracelet
}



