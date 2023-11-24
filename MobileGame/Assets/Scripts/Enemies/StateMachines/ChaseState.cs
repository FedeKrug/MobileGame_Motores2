using UnityEngine;

public class ChaseState : State
{
	[SerializeField] private State _attackState;
	[SerializeField] public bool isInAttackRange;
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
			return this;
	}
}
