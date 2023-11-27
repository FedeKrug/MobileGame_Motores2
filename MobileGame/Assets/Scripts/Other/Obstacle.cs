using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Obstacle : MonoBehaviour
{
	[SerializeField] private float _damage;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerHealth.instance.TakeDamage(_damage);
		}
	}

}
