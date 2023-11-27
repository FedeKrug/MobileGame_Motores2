using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyHealth : MonoBehaviour, IDamagable
{

	[SerializeField] private Transform _deathPlace;
	[SerializeField] private GameObject _meshToTurnOff;
	[SerializeField] protected int _manaCharge;

	[SerializeField] protected EnemyCounter counterRef;
	[SerializeField] protected float _health;
	[SerializeField] protected EnemyDeathDrop _dropRef;
	[SerializeField] protected Animator _anim;
	[SerializeField] protected string _hitAnimationTrigger = "hit";
	[SerializeField] protected float _damageEffectTime = 0.2f;
	public void TakeDamage(float damage)
	{
		_health -= damage;
		/*
		 Feedback de daño
		 */
		StartCoroutine(CO_useDamageEffect());
		CheckDeath();

	}

	protected void CheckDeath()
	{
		if (_health <= 0)
		{
			Die();
		}
	}

	IEnumerator CO_useDamageEffect()
	{
		_anim.SetTrigger(_hitAnimationTrigger);
		yield return new WaitForSeconds(_damageEffectTime);
		_anim.ResetTrigger(_hitAnimationTrigger);
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
