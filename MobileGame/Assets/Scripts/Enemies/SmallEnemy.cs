using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.GraphicsBuffer;

public class SmallEnemy : MonoBehaviour
{
	[SerializeField] private float _damage=3;
	[SerializeField] private float _movementSpeed;
	[SerializeField] private float _maxVelocity;
	[SerializeField] private float _offset;
	private Rigidbody _rb;
	private Vector3 _target;
	private Vector3 _velocity;
	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
		_target = GameManager.instance.PlayerPos.position;
	}

	private void Update()
	{
		Move();
		transform.position += _velocity * Time.deltaTime;
		transform.forward = _velocity;
	}


	private void Move()
	{
		_target = GameManager.instance.PlayerPos.position;
		var desired = _target - transform.position;
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
