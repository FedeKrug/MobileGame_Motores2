using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	[SerializeField] private Transform _shootingPoint;
	[SerializeField] private bool _moving;
	[SerializeField] EnemyCounter _enemyCounterRef;
	[SerializeField] private PlayerAutoAim _playerAim;
	[SerializeField] private bool _canAim;
	//[SerializeField] private ProjectileSoundEffect _projectileSoundEffect;
	[SerializeField] private AudioClip _shootSoundEffect;
	private AudioSource _aSource;


	private float _maxTime;
	private float _timer;

	public bool Moving
	{
		get => _moving;
		set => _moving = value;
	}
	public EnemyCounter EnemyCounterRef
	{
		get => _enemyCounterRef;
		set => _enemyCounterRef = value;
	}
	public Transform ShootingPoint
	{
		get => _shootingPoint;
		set =>
			_shootingPoint = value;
	}

	void Start()
	{
		_maxTime = GameManager.instance.PlayerStats.atkCooldown;
		_aSource = GetComponent<AudioSource>();
		_timer = _maxTime;
	}

	void Update()
	{
		_canAim = !_moving && _enemyCounterRef.areThereEnemiesInCounter;
		if (!_canAim)
		{
			_playerAim.enabled = false;
			return;
		}
		_timer -= Time.deltaTime;
		_playerAim.enabled = true;

		if (_timer <= 0)
		{
			Shoot(ProjectileFactory.instance.pool.GetObject().gameObject);
		}
	}

	public void Shoot(GameObject projectile)
	{
		projectile.transform.SetPositionAndRotation(_shootingPoint.position, _shootingPoint.rotation);
		_timer = _maxTime;
		_aSource.PlayOneShot(_shootSoundEffect);
	}


}
