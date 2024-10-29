using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace SHOP
{
	public class BuyableItem : MonoBehaviour
	{
		[SerializeField] Color itemNotSelectedColor;
		[SerializeField] Color itemSelectedColor;
		
		[Space (20f)]
		[SerializeField] Image buyableItemImage; 
		[SerializeField] TMP_Text buyableItemNameText; 
		[SerializeField] Image buyableItemPowerFill; 
		[SerializeField] TMP_Text buyableItemPriceText; 
		[SerializeField] Button buyableItemPurchaseButton;
		[SerializeField] Button buyableItemSoldButton;
		
		[Space (20f)]
		[SerializeField] Button itemButton;
		[SerializeField] Image itemImage;
		[SerializeField] Outline itemOutline;

		
		public void SetItemPosition (Vector2 pos)
		{
			GetComponent <RectTransform> ().anchoredPosition += pos;
		}



		public void SetItemImage (Sprite sprite)
		{
			buyableItemImage.sprite = sprite;
		}

		public void SetItemName (string name)
		{
			buyableItemNameText.text = name;
		}
		
		public void SetItemPower (float power)
		{
			buyableItemPowerFill.fillAmount = power / 10;
		}

		public void SetItemPrice (int price)
		{
			buyableItemPriceText.text = price.ToString ();
		}

		public void SetItemAsPurchased ()
		{
			buyableItemPurchaseButton.gameObject.SetActive (false);
			itemOutline.enabled = false;
			buyableItemSoldButton.gameObject.SetActive (true);

			itemButton.interactable = true;

			itemImage.color = itemNotSelectedColor;
		}

		public void SetItemAsTooExpensive()
		{
			buyableItemPriceText.color = Color.red;
		}
		
		public void SetItemAsBuyable()
		{
			buyableItemPriceText.color = Color.white;
		}

		public void OnItemPurchase (int itemIndex, UnityAction<int> action)
		{
			buyableItemPurchaseButton.onClick.RemoveAllListeners ();
			buyableItemPurchaseButton.onClick.AddListener (() => action.Invoke (itemIndex));
		}
	}
}
