using UnityEngine;

namespace SHOP
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] ShopDataBase shopDataBase; 
        [SerializeField] BuyableItem[] buyableItems;
        
        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private Item[] itemsToPickUp;

        void Start()
        {
            UpdateShopItems();
        }

        void UpdateShopItems()
        {
            for (int i = 0; i < buyableItems.Length; i++)
            {
                if (i < shopDataBase.CharactersCount)
                {
                    Item item = shopDataBase.GetItem(i);
                    BuyableItem buyableItem = buyableItems[i];

                    buyableItem.SetCharacterName(item.name);
                    buyableItem.SetCharacterImage(item.image);
                    buyableItem.SetCharacterPower(item.power);
                    buyableItem.SetCharacterPrice(item.price);

                    if (item.isPurchased)
                    {
                        buyableItem.SetItemAsPurchased();
                    }
                    else
                    {
                        buyableItem.OnItemPurchase(i, OnItemPurchased);
                    }
                }

            }
        }


        void OnItemPurchased (int index)
        {
            Item item = shopDataBase.GetItem(index);
            BuyableItem buyableItem = buyableItems[index];

            if (GameDataManager.CanSpendCoins (item.price)) {
                GameDataManager.SpendCoins (item.price);

                GameSharedUI.instance.UpdateCoinsUIText ();

                shopDataBase.PurchaseItem (index);
                inventoryManager.AddItem(itemsToPickUp[index]);
                buyableItem.SetItemAsPurchased();
                

            } else {
                Debug.Log("Not enough coins..");
            }
        }
        
    }
}