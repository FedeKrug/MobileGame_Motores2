using UnityEngine;

namespace Enemies.Mummy
{

	public class AttackState : State
	{
		[SerializeField] private ChaseState _chaseState;



		public override State RunCurrentState()
		{
			if (_chaseState.isInAttackRange)
			{

				return this;
			}
			else
			{
				return _chaseState;
			}

		}
	}
}