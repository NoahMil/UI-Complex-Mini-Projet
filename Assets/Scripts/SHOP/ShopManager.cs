using System;
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
            Invoke(nameof(UpdateShopItems), 1f);
            
        }
        
        public void UpdateShopItems()
        {
            for (int i = 0; i < buyableItems.Length; i++)
            {
                if (i < shopDataBase.CharactersCount)
                {
                    Item item = shopDataBase.GetItem(i);
                    BuyableItem buyableItem = buyableItems[i];

                    if (item.price > GameDataManager.GetCoins())
                    {
                        buyableItem.SetItemAsTooExpensive();
                    }
                    
                    if (item.price <= GameDataManager.GetCoins())
                    {
                        buyableItem.SetItemAsBuyable();
                    }

                    buyableItem.SetItemName(item.name);
                    buyableItem.SetItemImage(item.image);
                    buyableItem.SetItemPower(item.power);
                    buyableItem.SetItemPrice(item.price);

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
                UpdateShopItems();
            }
        }
        
    }
}