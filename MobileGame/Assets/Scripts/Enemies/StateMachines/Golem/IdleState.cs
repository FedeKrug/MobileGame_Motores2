using UnityEngine;

namespace Enemies.Golem
{
	public class IdleState : State
	{
		[SerializeField] private State _chaseState;
		[SerializeField] public bool canSeePlayer;


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
