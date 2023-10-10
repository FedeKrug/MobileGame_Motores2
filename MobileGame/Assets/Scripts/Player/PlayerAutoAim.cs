using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerAutoAim : MonoBehaviour
{
	[SerializeField] private Enemy[] _enemiesTotalAmount;
	private Enemy closestEnemy;
	
	private void OnEnable()
	{
		closestEnemy = FindClosestEnemy();
	}
	private void Update()
	{
		//if (_playerShootingRef.Moving || !EnemyManager.instance.activeCounter.enemiesInCounter ) return;
		
		closestEnemy = FindClosestEnemy();
		// Si hay un enemigo cercano, apuntamos al enemigo y disparamos.
		if (closestEnemy != null)
		{
			// Apuntamos al enemigo.
			transform.LookAt(closestEnemy.transform.position);

			// Disparamos al enemigo.
			Fire();
		}
	}

	// Dispara un proyectil.
	private void Fire()
	{
		//PlayerShooting se va a encargar de eso  
		//_playerShootingRef.Shoot();
		Debug.Log("Shoot from Player Auto Aim");
	}

	private Enemy FindClosestEnemy()
	{
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
