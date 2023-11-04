using System.Collections;
using UnityEngine;



public class VenomousProjectile : ExplosiveProjectile
{
	[SerializeField] private float _venomCooldown;
	[SerializeField] private float _venomDamage;
	private bool _poisoned;


	protected override void OnTriggerEnter(Collider other)
	{
		EnemyHealth enemyRef = other.gameObject.GetComponent<EnemyHealth>();

		if (enemyRef)
		{
			enemyRef.TakeDamage(_damage);
			Explode();

		}

	}
	private void OnTriggerStay(Collider other)
	{
		EnemyHealth enemyRef = other.gameObject.GetComponent<EnemyHealth>();


		if (enemyRef && _poisoned)
		{

			enemyRef.TakeDamage(_venomDamage);

		}
	}


	private IEnumerator UseVenomEffect()
	{
		_speed = 0;
		
		yield return null;
		_spellMesh.SetActive(false);
		_explosionEffect.SetActive(true);
		_aSource.PlayOneShot(_explosionSound);
		StartCoroutine(UseVenomousEffect());
		yield return new WaitForSeconds(_explosionDuration);
		Reset();
	}

	private IEnumerator UseVenomousEffect()
	{
		_poisoned = true;
		yield return new WaitForSeconds(_venomCooldown);
		_poisoned = false;
		StartCoroutine(UseVenomousEffect());
	}

	private void Explode()
	{
		StartCoroutine(UseVenomEffect());
	}
}