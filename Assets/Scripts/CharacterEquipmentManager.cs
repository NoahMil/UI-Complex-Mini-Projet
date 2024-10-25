using UnityEngine;

public class CharacterEquipmentManager : MonoBehaviour
{
    private Item _weaponItem;
    private Item _scarfItem;
    private Item _ringItem;

    public Item GetWeaponItem()
    {
        return _weaponItem;
    }
    
    public Item GetScarfItem()
    {
        return _scarfItem;
    }
    
    public Item GetRingItem()
    {
        return _ringItem;
    }

    public void SetWeaponItem(Item weaponItem)
    {
        this._weaponItem = weaponItem;
    }
    
    public void SetScarfItem(Item scarfItem)
    {
        this._scarfItem = scarfItem;
    }
    
    public void SetRingItem(Item ringItem)
    {
        this._ringItem = ringItem;
    }
}
