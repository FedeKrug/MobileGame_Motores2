
using System.Collections;

using UnityEngine;

public class ExplosiveProjectile : MagicProjectile
{
	[SerializeField] protected GameObject _explosionEffect;
	[SerializeField] protected AudioSource _aSource;
	[SerializeField] protected AudioClip _explosionSound;
	[SerializeField] protected GameObject _spellMesh;
	[SerializeField] protected float _explosionForce;
	[SerializeField] protected float _explosionRadius;
	[SerializeField] protected float _explosionMod;
	[SerializeField] protected float _explosionDuration;

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
		_speed = 0;
		_rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, _explosionMod, ForceMode.Impulse);
		yield return null;
		_spellMesh.SetActive(false);
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
