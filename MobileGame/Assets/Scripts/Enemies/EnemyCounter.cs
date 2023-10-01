using UnityEngine;
using System.Collections.Generic;

public class EnemyCounter : MonoBehaviour
{
	//TODO: Usar el EnemyCounter para ayudar al player a apuntar automaticamente

	[SerializeField] private int _enemyCount = 1;
	public bool enemiesInCounter = true;
	public bool playerInCounter = false;
	[SerializeField] private List<Enemy> _enemiesInCounter = new ();


	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy") && !_enemiesInCounter.Contains(other.GetComponent<Enemy>()))
		{
			_enemiesInCounter.Add(other.GetComponent<Enemy>());
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
		if (other.CompareTag("Enemy") && _enemiesInCounter.Contains(other.GetComponent<Enemy>()))
		{
			_enemiesInCounter.Remove(other.GetComponent<Enemy>());
			_enemyCount--;
			UpdateCounter();
		}
		if (other.CompareTag("Player"))
		{
			playerInCounter = false;
		}

	}

	private void UpdateCounter()
	{
		Debug.Log("Enemigos dentro del trigger: " + _enemyCount);
		// Puedes ejecutar aquí cualquier acción adicional basada en el contador de enemigos.
	}


}
