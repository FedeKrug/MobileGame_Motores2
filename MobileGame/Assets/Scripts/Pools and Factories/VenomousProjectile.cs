//using System.Collections;
//using UnityEngine;



//public class VenomousProjectile : ExplosiveProjectile
//{
//	[SerializeField] private float _poisonCooldown;
//	[SerializeField] private float _poisonDamage;
//	private bool _poisoned;


//	protected override void OnTriggerEnter(Collider other)
//	{
//		EnemyHealth enemyRef = other.gameObject.GetComponent<EnemyHealth>();

//		if (enemyRef)
//		{
//			enemyRef.TakeDamage(_damage);
//			Explode();

//		}

//	}
//	private void OnTriggerStay(Collider other)
//	{
//		EnemyHealth enemyRef = other.gameObject.GetComponent<EnemyHealth>();


//		if (enemyRef && _poisoned)
//		{

//			enemyRef.TakeDamage(_poisonDamage);

//		}
//	}


//	private IEnumerator UseVenomEffect()
//	{
//		_speed = 0;

//		yield return null;
//		_spellMesh.SetActive(false);
//		_explosionEffect.SetActive(true);
//		_aSource.PlayOneShot(_explosionSound);
//		StartCoroutine(UseVenomousEffect());
//		yield return new WaitForSeconds(_explosionDuration);
//		Reset();
//	}

//	private IEnumerator UseVenomousEffect()
//	{
//		_poisoned = true;
//		yield return new WaitForSeconds(_poisonCooldown);
//		_poisoned = false;
//		StartCoroutine(UseVenomousEffect());
//	}

//	private void Explode()
//	{
//		StartCoroutine(UseVenomEffect());
//	}
//}
using UnityEngine;

public class VenomousProjectile : MonoBehaviour
{
	[SerializeField] private int _poisonDamage = 5;
	[SerializeField] private float _poisonDuration = 3f;
	private float _timer = 0f;

	void Update()
	{
		EnemyHealth enemyRef = GetComponent<EnemyHealth>();
		if (!enemyRef) return;

		_timer += Time.deltaTime;
		if (_timer >= _poisonDuration)
		{
			// Apply poison damage
			enemyRef.TakeDamage(_poisonDamage);


			// Set the next poison time
			_timer = 0;
		}
	}
}
