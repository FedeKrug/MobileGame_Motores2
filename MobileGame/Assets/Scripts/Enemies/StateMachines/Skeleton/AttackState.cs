using UnityEngine;

namespace Enemies.Skeleton
{

	public class AttackState : State
	{
		[SerializeField] private ChaseState _chaseState;
		[SerializeField] private Animator _anim;
		[SerializeField] private string _attackAnimation = "Attack"; 

		public override State RunCurrentState()
		{
			if (_chaseState.isInAttackRange)
			{

				_anim.Play(_attackAnimation);
				return this;
			}
			else
			{
				return _chaseState;
			}

		}
	}
}