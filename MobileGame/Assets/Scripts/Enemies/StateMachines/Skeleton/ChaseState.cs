using UnityEngine;

namespace Enemies.Skeleton
{

	public class ChaseState : State
	{
		[SerializeField] private State _attackState;
		public bool isInAttackRange;
		[SerializeField] private IdleState _idleState;
		public override State RunCurrentState()
		{
			if (isInAttackRange)
			{
				return _attackState;
			}
			else if (!isInAttackRange && !_idleState.canSeePlayer)
			{
				return _idleState;
			}
			else
			{
				_idleState.anim.SetBool(_idleState.walkingAnimationParameter, true);
				return this;
			}
		}
	}

}