using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
	[SerializeField] private Image _icon = null;
	[SerializeField] private TextMeshProUGUI _itemName;
	[SerializeField] private TextMeshProUGUI _itemPrice;
	[SerializeField] private Button _itemButton;
	private int _priceValue;

	private void Start()
	{
		_priceValue = int.Parse(_itemPrice.text);
	}
	public void SetItem(StoreItemSO itemToRepresent)
	{
		_icon.sprite = itemToRepresent.itemSprite;
		_itemName.text = itemToRepresent.itemName;
		_itemPrice.text = itemToRepresent.itemPrice.ToString();
		//_itemPrice.text = string.Format("${00:00}", itemToRepresent.itemPrice.ToString());
		//_scoreText.text = string.Format("Coins: {0:000}", _saveData.coins);
	}

	public void BuyItem()
	{
		if (DataManager.instance.data.coins < _priceValue)
		{
			Debug.Log("No tienes suficiente dinero, mira una ad para conseguir mas monedas");
			return;
		}
		int newCoinsCant = DataManager.instance.data.coins -= _priceValue;
		DataManager.instance.data.coins = newCoinsCant;
		Debug.Log("Objeto comprado");
		MenuManager.instance.UpdateMenuUI();
	}
}
