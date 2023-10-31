
using System.Collections;
using UnityEngine;

public class ExplosiveProjectile : MagicProjectile
{
	[SerializeField] private GameObject _explosionEffect;
	[SerializeField] private AudioSource _aSource;
	[SerializeField] private AudioClip _explosionSound;
	[SerializeField] private float _explosionForce;
	[SerializeField] private float _explosionRadius;
	[SerializeField] private float _explosionMod;
	[SerializeField] private float _explosionDuration;

	[SerializeField] private Rigidbody _rb;
	protected override void OnTriggerEnter(Collider other)
	{
		Enemy enemyRef = other.gameObject.GetComponent<Enemy>();

		if (enemyRef)
		{
			enemyRef.TakeDamage(_damage);
			Explode();
			
		}

	}
	private IEnumerator useExplosionEffect()
	{
		_rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, _explosionMod, ForceMode.Impulse);
		yield return null;
		_explosionEffect.SetActive(true);
		_aSource.PlayOneShot(_explosionSound);
		yield return new WaitForSeconds(_explosionDuration);
		Reset();
	}


	private void Explode()
	{
		StartCoroutine(useExplosionEffect());
	}
}
