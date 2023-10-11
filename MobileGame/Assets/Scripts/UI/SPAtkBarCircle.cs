using UnityEngine;
using UnityEngine.UI;

public class SPAtkBarCircle : MonoBehaviour
{

	[SerializeField] private Image _spBar;
	[SerializeField] private float _maxMana = 1500;
	private float _currentMana = 0;
	private void Start()
	{
		_spBar.fillAmount = _currentMana;
	}
	public void IncreaseManaAmount(float manaObtained)
	{
		_currentMana += manaObtained;
		_spBar.fillAmount = _currentMana / _maxMana;
		CheckManaAmount();
	}

	private void CheckManaAmount()
	{
		if (_currentMana >= _maxMana)
		{
			_currentMana = _maxMana;
		}
	}
}
