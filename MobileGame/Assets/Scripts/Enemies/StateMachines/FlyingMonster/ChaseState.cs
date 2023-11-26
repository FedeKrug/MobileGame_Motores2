using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using static UnityEngine.GraphicsBuffer;

namespace Enemies.MonsterBat
{

	public class ChaseState : State
	{
		[SerializeField] private IdleState _idleState;
		[SerializeField] private float _movementSpeed;
		[SerializeField] private float _maxVelocity;
		[SerializeField] private GameObject _body;
		[SerializeField] private AttackState _attackState;
		public EnemyDetector attackRangeDetector;
		private Vector3 _velocity;
		private Vector3 _target;

		public override State RunCurrentState()
		{
			if (!_idleState.enemyDetector.playerDetected)
			{
				return _idleState;
			}

			if (attackRangeDetector.playerDetected)
			{
				return _attackState;
			}

			else
			{
				//Chase
				Move();
				_body.transform.position += _velocity * Time.deltaTime;
				_body.transform.forward = _velocity;
				return this;
			}
		}
		private void Move()
		{
			_target = GameManager.instance.PlayerPos.position;
			var desired = _target - _body.transform.position;
			desired = desired.normalized * _movementSpeed;

			Vector3 steering = desired - _velocity;
			steering = Vector3.ClampMagnitude(steering, _movementSpeed);

			AddForce(steering);
		}
		public void AddForce(Vector3 dir)
		{
			_velocity += dir;

			if (_velocity.magnitude > _maxVelocity)
				_velocity = _velocity.normalized * _maxVelocity;
		}
	}

}
