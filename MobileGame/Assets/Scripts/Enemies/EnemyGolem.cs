using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGolem : Enemy
{
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

	public override void Death()
	{
		throw new System.NotImplementedException();
	}

	protected override void Attack()
	{
		throw new System.NotImplementedException();
	}

	protected override bool attackCondition()
	{
		throw new System.NotImplementedException();
	}

	protected override void Move()
	{
		
	}
}
