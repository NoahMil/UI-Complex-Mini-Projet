using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CharacterEquipmentManager : MonoBehaviour
{
    private Item _weaponItem;
    private Item _scarfItem;
    private Item _ringItem;
    private Item _headbandItem;
    private Item _cloakItem;
    private Item _braceletItem;

    public enum EquipSlot
    {
        Weapon,
        Scarf,
        Ring,
        Headband,
        Cloak,
        Bracelet,
    }
    
    [SerializeField] private GameObject pickaxePrefab;
    [SerializeField] private GameObject scarfPrefab;
    [SerializeField] private GameObject ringPrefab;
    [SerializeField] private GameObject headbandPrefab;
    [SerializeField] private GameObject cloakPrefab;
    [SerializeField] private GameObject braceletPrefab;
    
    private void SetWeaponItem(Item weaponItem)
    {
        _weaponItem = weaponItem;
        pickaxePrefab.SetActive(true);
    }
    
    private void SetScarfItem(Item scarfItem)
    {
        _scarfItem = scarfItem;
        if (scarfPrefab != null)
        {
            scarfPrefab.SetActive(true);
        }    
    }

    private void SetRingItem(Item ringItem)
    {
        _ringItem = ringItem;
        if (ringPrefab != null)
        {
            ringPrefab.SetActive(true);
        }  
    }
    
    private void SetHeadbandItem(Item headbandItem)
    {
        _headbandItem = headbandItem;
        if (headbandPrefab != null)
        {
            headbandPrefab.SetActive(true);
        }  
    }
    
    private void SetCloakItem(Item cloakItem)
    {
        _cloakItem = cloakItem;
        if (cloakPrefab != null)
        {
            cloakPrefab.SetActive(true);
        }  
    }
    
    private void SetBraceletItem(Item braceletItem)
    {
        _braceletItem = braceletItem;
        if (braceletPrefab != null)
        {
            braceletPrefab.SetActive(true);
        }  
    }

    public void TryEquipItem(EquipSlot equipSlot, Item item)
    {
        if (equipSlot == item.GetEquipSlot())
        {
            switch (equipSlot)
            {
                case EquipSlot.Weapon : SetWeaponItem(item); 
                    Debug.Log("VRAI");
                    break;
                case EquipSlot.Scarf : SetScarfItem(item);
                    Debug.Log("VRAI");
                    break;
                case EquipSlot.Ring : SetRingItem(item);
                    Debug.Log("VRAI");
                    break;
                case EquipSlot.Headband : SetHeadbandItem(item);
                    Debug.Log("VRAI");

                    break;
                case EquipSlot.Cloak : SetCloakItem(item);
                    Debug.Log("VRAI");

                    break;
                case EquipSlot.Bracelet : SetBraceletItem(item);
                    Debug.Log("VRAI");

                    break;
            }
        }
    }
    
    public bool TryItem(EquipSlot equipSlot, Item item)
    {
        if (equipSlot == item.GetEquipSlot())
        {
            switch (equipSlot)
            {
                case EquipSlot.Weapon : return true;
                case EquipSlot.Scarf : return true;
                case EquipSlot.Ring : return true;
                case EquipSlot.Headband : return true;
                case EquipSlot.Cloak : return true;
                case EquipSlot.Bracelet : return true;
            }
        }

        return false;
    }
    
}