using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowAbilitySO : MonoBehaviour
{
	[Header("Scriptable Object Refs:")]
	[SerializeField] private AbilitiesSO _abilityRef;
	[SerializeField] private Image _icon;
	[SerializeField] private TextMeshProUGUI _textMastery;
	[SerializeField] private TextMeshProUGUI _textName;

	//initial State

	private string _textMasteryInit = "";
	private string _textNameInit = "";

	[Space(10)]
	[Header("Selection & Interactions:")]
	[SerializeField, Tooltip("TODO: Modificar width y height cuando es seleccionado")] private RectTransform _iconRTransform;
	[SerializeField] private float _initWidth = 60, _initHeight = 60, _modWidth, _modHeight;
	private Rect _rTransform;

	private void Start()
	{
		_rTransform.width = _initWidth;
		_rTransform.height = _initHeight;
		_textMastery.text = _textMasteryInit;
		_textName.text = _textNameInit;
	}


	public void Select()
	{
		_icon = _abilityRef.abilityIcon;
		_textMastery.text = _abilityRef.abilityMastery.ToString();
		_textName.text = _abilityRef.abilityName;

		_rTransform.width = _modWidth;
		_rTransform.height = _modHeight;
	}

	public void Deselect()
	{
		_rTransform.width = _initWidth;
		_rTransform.height = _initHeight;

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
