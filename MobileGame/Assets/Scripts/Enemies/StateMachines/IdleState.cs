using UnityEngine;
public class IdleState : State
{
	[SerializeField] private State _chaseState;
	[SerializeField] private bool _canSeePlayer;


	public override State RunCurrentState()
	{
		if (_canSeePlayer)
		{
			return _chaseState;
		}
		else
		{

			return this;
		}
	}
}
