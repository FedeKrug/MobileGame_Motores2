using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerAutoAim : MonoBehaviour
{
	[SerializeField] private Enemy[] _enemiesTotalAmount;
	[SerializeField] private PlayerShooting _playerShootingRef;

	private Enemy closestEnemy;
	
	private void OnEnable()
	{
		closestEnemy = FindClosestEnemy();
	}
	private void Update()
	{
		//if (_playerShootingRef.Moving || !EnemyManager.instance.activeCounter.enemiesInCounter ) return;
		
		closestEnemy = FindClosestEnemy();
		
		if (closestEnemy != null)
		{
			transform.LookAt(new Vector3(closestEnemy.transform.position.x, transform.position.y, closestEnemy.transform.position.z));
		}
	}

	private Enemy FindClosestEnemy()
	{
		for (int i =0; i<_enemiesTotalAmount.Length; i++)
		{
		_enemiesTotalAmount[i] = _playerShootingRef.EnemyCounterRef.EnemiesInCounter[i];

		}

		// Encuentra el enemigo más cercano al jugador.
		float closestDistance = float.MaxValue;
		Enemy closestEnemy = null;

		for (int i = 0; i < _enemiesTotalAmount.Length; i++)
		{
			float distance = Vector3.Distance(transform.position, _enemiesTotalAmount[i].transform.position);
			if (distance < closestDistance)
			{
				closestDistance = distance;
				closestEnemy = _enemiesTotalAmount[i];
			}
		}

		return closestEnemy;
	}

}
