using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerShootingTest : MonoBehaviour
{
	[SerializeField] private Transform _shootingPoint;
	[SerializeField] private bool _moving;
	private float _maxTime;
	private float _timer;

	public bool Moving
	{
		get => _moving;
		set => _moving = value;
	}

	void Start()
	{
		_maxTime = PlayerManager.instance.PlayerStats.atkCooldown;
		_timer = _maxTime;
	}

	void Update()
	{
		if (!_moving) return;
		_timer -= Time.deltaTime;
		if (_timer <= 0)
		{
			Shoot();
		}

	}

	private void Shoot()
	{
		Projectile projectileRef = ProjectileFactory.Instance.pool.GetObject();
		projectileRef.transform.SetPositionAndRotation(_shootingPoint.position, transform.rotation);
		Debug.Log("Shoot()");
		_timer = _maxTime;
	}
}
