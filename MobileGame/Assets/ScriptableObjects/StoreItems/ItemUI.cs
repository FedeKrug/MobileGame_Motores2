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
	public bool onStock;
	public void SetItem(StoreItemSO itemToRepresent)
	{
		_icon.sprite = itemToRepresent.itemSprite;
		_itemName.text = itemToRepresent.itemName;
		_itemPrice.text = string.Format("${00:00}", itemToRepresent.itemPrice.ToString());
		//_scoreText.text = string.Format("Coins: {0:000}", _saveData.coins);
		_itemButton.enabled = onStock;
	}

	public void BuyItem(StoreItemSO itemToRepresent)
	{
		onStock = false;
		itemToRepresent.itemPrice -= DataManager.instance.data.coins;
	}
}
