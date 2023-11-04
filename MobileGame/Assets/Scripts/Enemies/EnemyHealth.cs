using UnityEngine;
using UnityEngine.AI;


public class EnemyHealth : MonoBehaviour, IDamagable
{
	
	[SerializeField] private Transform _deathPlace;
	[SerializeField] private GameObject _meshToTurnOff;
	[SerializeField] protected int _manaCharge;

	[SerializeField] protected EnemyCounter counterRef;
	[SerializeField] protected float _health;
	[SerializeField] protected EnemyDeathDrop _dropRef;

	public void TakeDamage(float damage)
	{
		_health -= damage;
		/*
		 Feedback de daño
		 */

		CheckDeath();
	}

	protected void CheckDeath()
	{
		if (_health <= 0)
		{
			Die();
		}
	}

	protected void Die()
	{
		_meshToTurnOff.SetActive(false);
		Vector3 lastPos = new(transform.position.x, 1.5f, transform.position.z);
		_dropRef.DropObjects(lastPos);
		GameManager.instance.SpAttackRef.IncreaseManaAmount(_manaCharge);
		transform.position = _deathPlace.position;
	}
}
