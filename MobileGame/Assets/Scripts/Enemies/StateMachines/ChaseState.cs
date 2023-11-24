using UnityEngine;

public class ChaseState : State
{
	[SerializeField] private State _attackState;
	[SerializeField] private bool _isInAttackRange;

	public override State RunCurrentState()
	{
		if (_isInAttackRange)
		{
			return _attackState;
		}

		return this;
	}
}
