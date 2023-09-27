using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    [SerializeField] private float _damage;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.GetComponent<Enemy>().TakeDamage(_damage);
			GetComponent<MagicProjectile>().Reset();
			Debug.Log("Enemy attacked");
		}
	}

}
