using System;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    private CharacterEquipmentSlot _weaponSlot;
    private CharacterEquipmentSlot _scarfSlot;
    private CharacterEquipmentSlot _ringSlot;
    private CharacterEquipmentManager _characterEquipmentManager;

    private void Awake()
    {
        _weaponSlot = transform.Find("weaponSlot").GetComponent<CharacterEquipmentSlot>();
        _scarfSlot = transform.Find("helmetSlot").GetComponent<CharacterEquipmentSlot>();
        _ringSlot = transform.Find("armorSlot").GetComponent<CharacterEquipmentSlot>();

        _weaponSlot.OnItemDropped += WeaponSlot_OnItemDropped;
        _scarfSlot.OnItemDropped += HelmetSlot_OnItemDropped;
        _ringSlot.OnItemDropped += ArmorSlot_OnItemDropped;
    }

    private void WeaponSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip Weapon: " + e.item);
        _characterEquipmentManager.SetWeaponItem(e.item);
    }

    private void HelmetSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip Helmet: " + e.item);
    }

    private void ArmorSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip Armor: " + e.item);
    }

    public void SetCharacterEquipment(CharacterEquipmentManager characterEquipmentManager)
    {
       this._characterEquipmentManager = characterEquipmentManager;
    }

    private void UpdateVisual()
    {
        
    }
}