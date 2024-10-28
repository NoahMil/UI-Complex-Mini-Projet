using UnityEngine;
using UnityEngine.Serialization;

namespace SHOP
{
    [CreateAssetMenu (menuName = "ScriptableObject/ShopDatabase")]
    public class ShopDataBase : ScriptableObject
    {
        public Item[] items;

        public int CharactersCount {
            get{ return items.Length; }
        }

        public Item GetItem (int index)
        {
            return items [index];
        }

        public void PurchaseItem (int index)
        {
            items [index].isPurchased = true;
        }
    }
}