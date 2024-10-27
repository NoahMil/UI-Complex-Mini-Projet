using System;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    [SerializeField] private CharacterEquipmentManager _characterEquipmentManager;

    [SerializeField] private CharacterEquipmentSlot _weaponSlot;
    [SerializeField]private CharacterEquipmentSlot _scarfSlot;
    [SerializeField] private CharacterEquipmentSlot _ringSlot;
    [SerializeField] private CharacterEquipmentSlot _headbandSlot;
    [SerializeField] private CharacterEquipmentSlot _cloakSlot;
    [SerializeField] private CharacterEquipmentSlot _braceletSlot;
    
    private void Awake()
    {
        _weaponSlot.OnItemDropped += WeaponSlot_OnItemDropped;
        _scarfSlot.OnItemDropped += ScarfSlot_OnItemDropped;
        _ringSlot.OnItemDropped += RingSlot_OnItemDropped;
        
        _headbandSlot.OnItemDropped += HeadbandSlot_OnItemDropped;
        _cloakSlot.OnItemDropped += CloakSlot_OnItemDropped;
        _braceletSlot.OnItemDropped += BraceletSlot_OnItemDropped;
    }

    private void WeaponSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip Weapon: " + e.item);
        _characterEquipmentManager.TryEquipItem(CharacterEquipmentManager.EquipSlot.Weapon, e.item);
    }
    
    private void ScarfSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip Scarf: " + e.item);
        _characterEquipmentManager.TryEquipItem(CharacterEquipmentManager.EquipSlot.Scarf, e.item);
    }

    private void RingSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip Ring: " + e.item);
        _characterEquipmentManager.TryEquipItem(CharacterEquipmentManager.EquipSlot.Ring, e.item);
    }
    
    private void HeadbandSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip Headband: " + e.item);
        _characterEquipmentManager.TryEquipItem(CharacterEquipmentManager.EquipSlot.Headband, e.item);
    }
    
    private void CloakSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip Cloak: " + e.item);
        _characterEquipmentManager.TryEquipItem(CharacterEquipmentManager.EquipSlot.Cloak, e.item);
    }
    
    private void BraceletSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip Bracelet: " + e.item);
        _characterEquipmentManager.TryEquipItem(CharacterEquipmentManager.EquipSlot.Bracelet, e.item);
    }

}