using UnityEngine;
using SHOP;

namespace MENU
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] ShopDataBase shopDataBase; 
        [SerializeField] BuyableItem[] buyableItems;

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
                buyableItem.SetItemAsPurchased();
                
                Debug.Log("BUY");

            } else {
                Debug.Log("Not enough coins..");
            }
        }

        
        BuyableItem GetItemUI(int index)
        {
            if (index >= 0 && index < buyableItems.Length)
            {
                return buyableItems[index];
            }
            Debug.LogWarning("Index hors limite dans buyableItems : " + index);
            return null;
        }

    }
}