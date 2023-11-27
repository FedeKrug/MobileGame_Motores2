using UnityEngine;

namespace Enemies.Skeleton
{
	public class IdleState : State
	{
		[SerializeField] private State _chaseState;
		public bool canSeePlayer;
		public Animator anim;
		public string walkingAnimationParameter;

		public override State RunCurrentState()
		{
			if (canSeePlayer)
			{
				return _chaseState;
			}
			else
			{
				anim.SetBool(walkingAnimationParameter, false);
				return this;
			}
		}
	}

}
