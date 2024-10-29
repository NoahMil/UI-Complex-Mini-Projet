using System;
using INVENTORY;
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
        _weaponSlot.OnItemRemoved += WeaponSlot_OnItemRemoved;

        _scarfSlot.OnItemDropped += ScarfSlot_OnItemDropped;
        _scarfSlot.OnItemRemoved += ScarfSlot_OnItemRemoved;

        _ringSlot.OnItemDropped += RingSlot_OnItemDropped;
        _ringSlot.OnItemRemoved += RingSlot_OnItemRemoved;

        _headbandSlot.OnItemDropped += HeadbandSlot_OnItemDropped;
        _headbandSlot.OnItemRemoved += HeadbandSlot_OnItemRemoved;

        _cloakSlot.OnItemDropped += CloakSlot_OnItemDropped;
        _cloakSlot.OnItemRemoved += CloakSlot_OnItemRemoved;

        _braceletSlot.OnItemDropped += BraceletSlot_OnItemDropped;
        _braceletSlot.OnItemRemoved += BraceletSlot_OnItemRemoved;
    }

    private void WeaponSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        _characterEquipmentManager.TryEquipItem(CharacterEquipmentManager.EquipSlot.Weapon, e.item);
    }
    
    private void ScarfSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        _characterEquipmentManager.TryEquipItem(CharacterEquipmentManager.EquipSlot.Scarf, e.item);
    }

    private void RingSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        _characterEquipmentManager.TryEquipItem(CharacterEquipmentManager.EquipSlot.Ring, e.item);
    }
    
    private void HeadbandSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        _characterEquipmentManager.TryEquipItem(CharacterEquipmentManager.EquipSlot.Headband, e.item);
    }
    
    private void CloakSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        _characterEquipmentManager.TryEquipItem(CharacterEquipmentManager.EquipSlot.Cloak, e.item);
    }
    
    private void BraceletSlot_OnItemDropped(object sender, CharacterEquipmentSlot.OnItemDroppedEventArgs e)
    {
        _characterEquipmentManager.TryEquipItem(CharacterEquipmentManager.EquipSlot.Bracelet, e.item);
    }
    
    private void WeaponSlot_OnItemRemoved(object sender, CharacterEquipmentSlot.OnItemRemovedEventArgs e)
    {
        _characterEquipmentManager.RemoveItem(CharacterEquipmentManager.EquipSlot.Weapon);
    }

    private void ScarfSlot_OnItemRemoved(object sender, CharacterEquipmentSlot.OnItemRemovedEventArgs e)
    {
        _characterEquipmentManager.RemoveItem(CharacterEquipmentManager.EquipSlot.Scarf);
    }

    private void RingSlot_OnItemRemoved(object sender, CharacterEquipmentSlot.OnItemRemovedEventArgs e)
    {
        _characterEquipmentManager.RemoveItem(CharacterEquipmentManager.EquipSlot.Ring);
    }

    private void HeadbandSlot_OnItemRemoved(object sender, CharacterEquipmentSlot.OnItemRemovedEventArgs e)
    {
        _characterEquipmentManager.RemoveItem(CharacterEquipmentManager.EquipSlot.Headband);
    }

    private void CloakSlot_OnItemRemoved(object sender, CharacterEquipmentSlot.OnItemRemovedEventArgs e)
    {
        _characterEquipmentManager.RemoveItem(CharacterEquipmentManager.EquipSlot.Cloak);
    }

    private void BraceletSlot_OnItemRemoved(object sender, CharacterEquipmentSlot.OnItemRemovedEventArgs e)
    {
        _characterEquipmentManager.RemoveItem(CharacterEquipmentManager.EquipSlot.Bracelet);
    }

}