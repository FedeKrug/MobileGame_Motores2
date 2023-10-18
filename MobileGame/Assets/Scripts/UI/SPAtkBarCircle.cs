using UnityEngine;
using UnityEngine.UI;

public class SPAtkBarCircle : MonoBehaviour
{

	[SerializeField] private Image _spBar;
	[SerializeField] private float _maxMana = 150;
	[SerializeField] private GameObject _superProjectile;


	private float _currentMana = 0;
	private bool _canShoot = false;

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
			_canShoot = true;
		}
	}

	public void ShootSpecialAttack()
	{
		if (!_canShoot) return;
		Debug.Log("Special Shoot");
	}

}
