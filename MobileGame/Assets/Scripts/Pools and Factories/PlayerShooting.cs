using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	[SerializeField] private Transform _shootingPoint;
	[SerializeField] private bool _moving;
	[SerializeField] EnemyCounter _enemyCounterRef;
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
		if (_moving || !_enemyCounterRef.enemiesInCounter ) return;
		_timer -= Time.deltaTime;
		if (_timer <= 0)
		{
			Shoot();
		}

	}

	private void Shoot()
	{
		//Aim (Apuntar)


		MagicProjectile projectileRef = ProjectileFactory.instance.pool.GetObject();
		projectileRef.transform.SetPositionAndRotation(_shootingPoint.position, transform.rotation);
		_timer = _maxTime;
	}
}
