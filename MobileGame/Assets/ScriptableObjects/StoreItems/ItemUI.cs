using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    [SerializeField] Image _icon = null;
    [SerializeField] TextMeshProUGUI _itemName;
    [SerializeField] TextMeshProUGUI _itemPrice;

    public void SetItem(StoreItemSO itemToRepresent)
    {
        _icon.sprite = itemToRepresent.itemSprite;
        _itemName.text = itemToRepresent.itemName;
        _itemPrice.text = string.Format( "${00:00}" ,itemToRepresent.itemPrice.ToString());
        //_scoreText.text = string.Format("Coins: {0:000}", _saveData.coins);
    }
}
