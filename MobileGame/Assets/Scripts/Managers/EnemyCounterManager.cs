using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyCounterManager : MonoBehaviour
{
	[SerializeField] private EnemyCounter[] enemyCounters;
	[SerializeField] private PlayerShooting _playerShootingRef;
	private EnemyCounter FindClosestEnemyCounter()
	{
		EnemyCounter activeEnemyCounter = null;


		for (int i = 0; i < enemyCounters.Length; i++)
		{
			if (enemyCounters[i].playerInCounter)
			{
				activeEnemyCounter = enemyCounters[i];
				_playerShootingRef.EnemyCounterRef = activeEnemyCounter;
			}
		}

		return activeEnemyCounter;
	}

	private void Update()
	{
		EnemyCounter activeEnemyCounter = FindClosestEnemyCounter();

		//if (activeEnemyCounter != null)
		//{
		//	Debug.Log("El player se encuentra el " + activeEnemyCounter.name);
		//}
	}
}
