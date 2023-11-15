using UnityEngine;
using UnityEngine.UI;

public class SPAtkBarCircle : MonoBehaviour
{

	[SerializeField] private Image _spBar;
	[SerializeField] private float _maxMana = 150;
	[SerializeField] private GameObject _superProjectile;
	[SerializeField] private PlayerShooting _playerShootingRef;

	private bool _projectileCreated;

	[SerializeField] private float _currentMana = 0;
	private bool _canShoot = false;

	private void Start()
	{
		_spBar.fillAmount = _currentMana;
	}
	public void IncreaseManaAmount(float manaObtained)
	{
		_currentMana += manaObtained;
		UpdateManaAmount();
	}

	private void CheckManaAmount()
	{
		if (_currentMana >= _maxMana)
		{
			_currentMana = _maxMana;
			_canShoot = true;
		}
		if (_currentMana <= 0)
		{
			_currentMana = 0;
			_canShoot = false;
		}
	}
	[ContextMenu("Update Mana Amount")]
	public void UpdateManaAmount()
	{
		_spBar.fillAmount = _currentMana / _maxMana;
		CheckManaAmount();
	}


	public void ShootSpecialAttack()
	{
		if (!_canShoot) return;
		Debug.Log("Special Shoot");
		if (!_projectileCreated)
		{
			Instantiate(_superProjectile, _playerShootingRef.ShootingPoint.position, _playerShootingRef.ShootingPoint.rotation);
		}

		_projectileCreated = true;

		_playerShootingRef.Shoot(_superProjectile);
		_currentMana = 0;
		UpdateManaAmount();
	}

}
