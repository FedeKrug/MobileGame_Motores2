using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityItemUI : StoreItem
{
 
    [SerializeField] TextMeshProUGUI _itemDescription;

    public void SetItem(AbilityItemSO itemToRepresent)
    {
        _icon.sprite = itemToRepresent.abilityIcon;
        _itemName.text = itemToRepresent.abilityName;
        _itemDescription.text = itemToRepresent.abilityDescription;
    }
}