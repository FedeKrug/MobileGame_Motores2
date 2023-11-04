using UnityEngine;
using System.Collections.Generic;

public class EnemyCounter : MonoBehaviour
{

	[SerializeField] private int _enemyCount = 1;
	public bool areThereEnemiesInCounter = true;
	public bool playerInCounter = false;
	[SerializeField] private List<EnemyHealth> _enemiesInCounter = new();

	public int EnemyCount
	{
		get => _enemyCount;
		set => _enemyCount = value;
	}
	public List<EnemyHealth> EnemiesInCounter { 
		get => _enemiesInCounter; 
		set => _enemiesInCounter = value;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy") && !_enemiesInCounter.Contains(other.GetComponent<EnemyHealth>()))
		{
			_enemiesInCounter.Add(other.GetComponent<EnemyHealth>());
			_enemyCount++;
			UpdateCounter();
		}
		if (other.CompareTag("Player"))
		{
			playerInCounter = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Enemy") && _enemiesInCounter.Contains(other.GetComponent<EnemyHealth>()))
		{
			_enemiesInCounter.Remove(other.GetComponent<EnemyHealth>());
			_enemyCount--;
			UpdateCounter();
		}
		if (other.CompareTag("Player"))
		{
			playerInCounter = false;
		}

	}

	private bool UpdateCounter()
	{
		if (_enemyCount <= 0)
		{
			areThereEnemiesInCounter = false;
		}
		return playerInCounter;
	}


}

