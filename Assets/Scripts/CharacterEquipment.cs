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
        _scarfSlot = transform.Find("headbandSlot").GetComponent<CharacterEquipmentSlot>();
        _ringSlot = transform.Find("ringSlot").GetComponent<CharacterEquipmentSlot>();

        _weaponSlot.OnItemDropped += WeaponSlot_OnItemDropped;
        _scarfSlot.OnItemDropped += HeadbandSlot_OnItemDropped;
        _ringSlot.OnItemDropped += RingSlot_OnItemDropped;
    }

    private void WeaponSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip Weapon: " + e.item);
        _characterEquipmentManager.SetWeaponItem(e.item);
    }

    private void HeadbandSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip Headband: " + e.item);
    }

    private void RingSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip Ring: " + e.item);
    }

    public void SetCharacterEquipment(CharacterEquipmentManager characterEquipmentManager)
    {
       this._characterEquipmentManager = characterEquipmentManager;
    }

    private void UpdateVisual()
    {
        
    }
}