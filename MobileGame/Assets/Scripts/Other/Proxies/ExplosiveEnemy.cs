﻿using UnityEngine;

public class ExplosiveEnemy : Enemy
{
	
	protected override void Move()
	{
		_anim.SetBool("isWalking", true);
		_agent.SetDestination(_target.position);
	}

	protected override bool attackCondition()
	{
		if (_distance <= Mathf.Pow(_rangeToAttack, 2))
		{
			Debug.Log("Attack");
			return true;
		}
		else
		{
			return false;
		}
	}
	protected override void Attack()
	{
		_anim.SetBool("Attack", true);
	}


	public override void Death()
	{
		Debug.Log($"Enemy Close Quarters is dead");
		gameObject.SetActive(false);
	}

	public override void animationAttack()
	{
		Collider[] hitObjs = Physics.OverlapSphere(_attckSpawnPoint.position, _attkRange);
		foreach (var obj in hitObjs)
		{
			if (obj.GetComponent<PlayerHealth>())
			{
				PlayerHealth.instance.TakeDamage(damage);
			}
		}
	}
}