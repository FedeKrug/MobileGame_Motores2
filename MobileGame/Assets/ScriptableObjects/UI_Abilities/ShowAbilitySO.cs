using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowAbilitySO : MonoBehaviour
{
	[Header("Scriptable Object Refs:")]
	[SerializeField] private AbilitiesSO _abilityRef;
	[SerializeField] private TextMeshProUGUI _textMastery;
	[SerializeField] private TextMeshProUGUI _textName;

	//initial State

	private string _textMasteryInit = "";
	private string _textNameInit = "";

	private void Start()
	{
		_textMastery.text = _textMasteryInit;
		_textName.text = _textNameInit;
	}


	public void Select()
	{
		_textMastery.text = _abilityRef.abilityMastery.ToString();
		_textName.text = _abilityRef.abilityName;
	}

	public void Deselect()
	{
		_textMastery.text = _textMasteryInit;
		_textName.text = _textNameInit;

	}
}

//[Lvl/exp]
//Arriba
//Character level -> int : 8
//Experience points(XP) -> float/float: 180/1500

//[HP/MP]
//No van en el menu?:
//Health points(HP) -> int/int : 50/100 
//Mana or energy points(MP/EP) -> int/int : 25/380

//[Damage]
//Van en el menu:
//Attack power(ATK)
//Defense or armor rating(DEF)
//Speed or agility
//Critical hit rate

//Elemental resistances?
