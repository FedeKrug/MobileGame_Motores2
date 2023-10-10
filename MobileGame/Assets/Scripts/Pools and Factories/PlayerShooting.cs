using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	[SerializeField] private Transform _shootingPoint;
	[SerializeField] private bool _moving;
	[SerializeField] EnemyCounter _enemyCounterRef;
	[SerializeField] private PlayerAutoAim _playerAim;
	private bool _canAim;

	//TODO: Cambiar el enemyCounterRef dependiendo del activeEnemyCounter (EnemyManager)
	private float _maxTime;
	private float _timer;

	public bool Moving
	{
		get => _moving;
		set => _moving = value;
	}

	void Start()
	{
		_maxTime = GameManager.instance.PlayerStats.atkCooldown;
		_timer = _maxTime;
	}

	void Update()
	{
		_canAim = !_moving && _enemyCounterRef.enemiesInCounter;
		if (!_canAim)
		{
			Debug.Log("Can't Aim");
			_playerAim.enabled = false;
			return;
		}
		_timer -= Time.deltaTime;
		_playerAim.enabled = true;
		if (_timer <= 0)
		{
			Shoot();
		}

	}

	public void Shoot()
	{
		//Aim (Apuntar)
		MagicProjectile projectileRef = ProjectileFactory.instance.pool.GetObject();
		projectileRef.transform.SetPositionAndRotation(_shootingPoint.position, transform.rotation);
		_timer = _maxTime;
	}


}
