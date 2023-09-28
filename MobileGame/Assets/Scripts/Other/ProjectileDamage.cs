using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    [SerializeField] private float _damage;
	[SerializeField] private MagicProjectile _projectileRef;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.GetComponent<Enemy>().TakeDamage(_damage);
			_projectileRef.Reset();
			Debug.Log("Enemy attacked");
		}
	}

}
