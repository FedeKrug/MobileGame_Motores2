using UnityEngine;
using System.Collections.Generic;

public class EnemyCounter : MonoBehaviour
{

	[SerializeField] private int _enemyCount = 1;
	public bool areThereEnemiesInCounter = true;
	public bool playerInCounter = false;
	[SerializeField] private List<EnemyHealth> _enemiesInCounter = new();
	[SerializeField] private List<Door> _doors;

	public int EnemyCount
	{
		get => _enemyCount;
		set => _enemyCount = value;
	}
	public List<EnemyHealth> EnemiesInCounter
	{
		get => _enemiesInCounter;
		set => _enemiesInCounter = value;
	}

	private void Update()
	{
		if (!areThereEnemiesInCounter && playerInCounter)
		{
			OpenDoors();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		EnemyBehaviour enemyRef = other.GetComponent<EnemyBehaviour>();
		if (enemyRef && !_enemiesInCounter.Contains(other.GetComponent<EnemyHealth>()))
		{
			_enemiesInCounter.Add(other.GetComponent<EnemyHealth>());
			_enemyCount++;
			UpdateCounter();
		}
		if (other.CompareTag("Player"))
		{
			for (int i = 0; i < _enemiesInCounter.Count; i++)
			{
				_enemiesInCounter[i].GetComponent<EnemyBehaviour>().TestBool = true;
			}
			playerInCounter = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		var enemyRef = other.CompareTag("Enemy");
		if (enemyRef && _enemiesInCounter.Contains(other.GetComponent<EnemyHealth>()))
		{
			_enemiesInCounter.Remove(other.GetComponent<EnemyHealth>());
			_enemyCount--;
			UpdateCounter();
		}
		if (other.CompareTag("Player"))
		{
			for (int i = 0; i < _enemiesInCounter.Count; i++)
			{
				_enemiesInCounter[i].GetComponent<EnemyBehaviour>().TestBool = false;
			}
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

	private void OpenDoors()
	{
		if (_doors.Count != 0)
		{

			for (int i = 0; i < _doors.Count; i++)
			{
				_doors[i].GoTroughTheDoor();
			}
		}

	}

}

