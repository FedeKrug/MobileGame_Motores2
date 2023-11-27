using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Enemies.MonsterBat
{

	public class IdleState : State
	{
		public EnemyDetector enemyDetector;
		[SerializeField] private ChaseState _chaseState;
		public override State RunCurrentState()
		{
			if (enemyDetector.playerDetected)
			{
				return _chaseState;
			}
			else
			{

			return this;
			}
		}
	}
}
