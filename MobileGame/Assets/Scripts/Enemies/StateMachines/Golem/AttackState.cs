using UnityEngine;

namespace Enemies.Golem
{

	public class AttackState : State
	{
		[SerializeField] private ChaseState _chaseState;
		[SerializeField] private Animator _anim;


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