using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : StoreItem
{
	
	[SerializeField] private TextMeshProUGUI _itemPrice;
	[SerializeField] private Button _itemButton;
	private int _priceValue;
	[HideInInspector] public int abilityMastery;


    private void Start()
	{
		_priceValue = int.Parse(_itemPrice.text);
	}
	public void SetItem(StoreItemSO itemToRepresent)
	{
		_icon.sprite = itemToRepresent.itemSprite;
		_itemName.text = itemToRepresent.abilityRef.name + " Boost";
		_itemPrice.text = itemToRepresent.itemPrice.ToString();
		_itemButton.onClick.AddListener(itemToRepresent.OnClick);
	}

	public void BuyItem()
	{
		if (DataManager.instance.data.coins < _priceValue)
		{
			Debug.Log("No tienes suficiente dinero, mira una ad para conseguir mas monedas");
			AdManager.instance.GetComponent<RewardedAd>().LoadAd();
			//return false;
		}
		else
		{
			int newCoinsCant = DataManager.instance.data.coins -= _priceValue;
			DataManager.instance.data.coins = newCoinsCant;
			Debug.Log("Objeto comprado");
			//Feedback de compra de objeto

			MenuManager.instance.UpdateMenuUI();
			//return true;
		}
	}
}
