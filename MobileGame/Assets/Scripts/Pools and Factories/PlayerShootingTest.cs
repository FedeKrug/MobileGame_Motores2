using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerShootingTest : MonoBehaviour
{
	[SerializeField] private Transform _shootingPoint;
	[SerializeField] private bool _moving;

	[SerializeField] private float _maxTime = 1.5f;
	private float _timer;

	public bool Moving
	{
		get => _moving;
		set => _moving = value;
	}

	void Start()
	{
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
		var p = ProjectileFactory.Instance.pool.GetObject();
		p.transform.SetPositionAndRotation(_shootingPoint.position, transform.rotation);
		Debug.Log("Shoot()");
		_timer = _maxTime;
	}
}
