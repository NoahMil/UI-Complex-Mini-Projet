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

		[Space (20f)]
		[SerializeField] Button itemButton;
		[SerializeField] Image itemImage;
		[SerializeField] Outline itemOutline;

		private void Start()
		{
			throw new NotImplementedException();
		}

		public void SetItemPosition (Vector2 pos)
		{
			GetComponent <RectTransform> ().anchoredPosition += pos;
		}

		public void SetCharacterImage (Sprite sprite)
		{
			buyableItemImage.sprite = sprite;
		}

		public void SetCharacterName (string name)
		{
			buyableItemNameText.text = name;
		}
		
		public void SetCharacterPower (float power)
		{
			buyableItemPowerFill.fillAmount = power / 10;
		}

		public void SetCharacterPrice (int price)
		{
			buyableItemPriceText.text = price.ToString ();
		}

		public void SetItemAsPurchased ()
		{
			buyableItemPurchaseButton.gameObject.SetActive (false);
			itemButton.interactable = true;

			itemImage.color = itemNotSelectedColor;
		}

		public void OnItemPurchase (int itemIndex, UnityAction<int> action)
		{
			buyableItemPurchaseButton.onClick.RemoveAllListeners ();
			buyableItemPurchaseButton.onClick.AddListener (() => action.Invoke (itemIndex));
		}

		public void OnItemSelect (int itemIndex, UnityAction<int> action)
		{
			itemButton.interactable = true;

			itemButton.onClick.RemoveAllListeners ();
			itemButton.onClick.AddListener (() => action.Invoke (itemIndex));
		}
		
		

		public void SelectItem ()
		{
			itemOutline.enabled = true;
			itemImage.color = itemSelectedColor;
			itemButton.interactable = false;
		}

		public void DeselectItem ()
		{
			itemOutline.enabled = false;
			itemImage.color = itemNotSelectedColor;
			itemButton.interactable = true;
		}
	}
}
