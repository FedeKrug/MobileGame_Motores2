using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Enemies.MonsterBat
{

	public class IdleState : State
	{
		public bool canSeePlayer;
		[SerializeField] private ChaseState _chaseState;
		public override State RunCurrentState()
		{
			if (canSeePlayer)
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
