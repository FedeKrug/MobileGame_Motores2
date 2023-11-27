using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Enemies.MonsterBat
{

	public class AttackState : State
	{
		[SerializeField] private float _damage;
		[SerializeField] private ChaseState _chaseState;
		[SerializeField] private float _attackCooldown;
		public override State RunCurrentState()
		{
			if (_chaseState.attackRangeDetector.playerDetected)
			{
				PlayerHealth.instance.TakeDamage(_damage);
				return this;
			}
			else
			{
	
				return _chaseState;
			}
		}

		
	}
}
