using UnityEngine;

namespace INVENTORY
{
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
        [SerializeField] private GameObject hammerPrefab;
        [SerializeField] private GameObject scarfPrefab;
        [SerializeField] private GameObject ringPrefab;
        [SerializeField] private GameObject headbandPrefab;
        [SerializeField] private GameObject cloakPrefab;
        [SerializeField] private GameObject braceletPrefab;
    
        private void SetWeaponItem(Item weaponItem)
        {
            _weaponItem = weaponItem;
 
            if (weaponItem.itemType == ItemType.Hammer)
            {
                hammerPrefab.SetActive(true);
            }
        
            else if (weaponItem.itemType == ItemType.PickAxe)
            {
                pickaxePrefab.SetActive(true);
            }
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
                        break;
                    case EquipSlot.Scarf : SetScarfItem(item);
                        break;
                    case EquipSlot.Ring : SetRingItem(item);
                        break;
                    case EquipSlot.Headband : SetHeadbandItem(item);
                        break;
                    case EquipSlot.Cloak : SetCloakItem(item);
                        break;
                    case EquipSlot.Bracelet : SetBraceletItem(item);
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
        
        public void RemoveItem(EquipSlot equipSlot)
        {
            switch (equipSlot)
            {
                case EquipSlot.Weapon:
                    _weaponItem = null;
                    if (pickaxePrefab != null) pickaxePrefab.SetActive(false);
                    if (hammerPrefab != null) hammerPrefab.SetActive(false);
                    break;
                case EquipSlot.Scarf:
                    _scarfItem = null;
                    if (scarfPrefab != null) scarfPrefab.SetActive(false);
                    break;
                case EquipSlot.Ring:
                    _ringItem = null;
                    if (ringPrefab != null) ringPrefab.SetActive(false);
                    break;
                case EquipSlot.Headband:
                    _headbandItem = null;
                    if (headbandPrefab != null) headbandPrefab.SetActive(false);
                    break;
                case EquipSlot.Cloak:
                    _cloakItem = null;
                    if (cloakPrefab != null) cloakPrefab.SetActive(false);
                    break;
                case EquipSlot.Bracelet:
                    _braceletItem = null;
                    if (braceletPrefab != null) braceletPrefab.SetActive(false);
                    break;
            }
        }

    }
    
    
    
    
}