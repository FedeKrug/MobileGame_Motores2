using UnityEngine;

namespace Enemies.Golem
{

	public class ChaseState : State
	{
		[SerializeField] private State _attackState;
		[SerializeField] public bool isInAttackRange;
		[SerializeField] private IdleState _idleState;
		[SerializeField] private Animator _anim;
		public override State RunCurrentState()
		{
			if (isInAttackRange)
			{
				_anim.SetBool("isWalking", false);
				_anim.SetBool("attack",true);
				return _attackState;
			}
			else if (!isInAttackRange && !_idleState.canSeePlayer)
			{
				return _idleState;
			}
			else
			{
				_anim.SetBool("isWalking", true);
				return this;
			}
		}
	}

}