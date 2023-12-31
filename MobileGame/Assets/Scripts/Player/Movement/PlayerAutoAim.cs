using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerAutoAim : MonoBehaviour
{
	[SerializeField] private EnemyHealth[] _enemiesTotalAmount;
	[SerializeField] private PlayerShooting _playerShootingRef;

	private EnemyHealth closestEnemy;

	private void OnEnable()
	{
		closestEnemy = FindClosestEnemy();
	}
	private void Update()
	{
		closestEnemy = FindClosestEnemy();

		if (closestEnemy != null)
		{
			transform.LookAt(new Vector3(closestEnemy.transform.position.x, transform.position.y, closestEnemy.transform.position.z));
		}
	}

	private EnemyHealth FindClosestEnemy()
	{
		for (int i = 0; i < _enemiesTotalAmount.Length; i++)
		{
			_enemiesTotalAmount[i] = _playerShootingRef.EnemyCounterRef.EnemiesInCounter[i];

		}

		// Encuentra el enemigo m�s cercano al jugador.
		float closestDistance = float.MaxValue;
		EnemyHealth closestEnemy = null;

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
