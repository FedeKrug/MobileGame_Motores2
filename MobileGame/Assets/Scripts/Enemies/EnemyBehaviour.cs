using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class EnemyBehaviour : MonoBehaviour
{
	Vector3 _velocity;
	Vector3 _target;
	//NavMeshAgent _agent;
	[SerializeField] protected bool _testBool;
	[SerializeField] protected bool _fleeBool;
	[SerializeField] protected float maxVelocity;
	[SerializeField] protected float maxSpeed;

	//protected virtual void Start()
	//{
	//	_agent = gameObject.GetComponent<NavMeshAgent>();
		
	//}

	protected virtual void Update()
	{
		if (_testBool)
		{
			Seek(_target);
			transform.position += _velocity * Time.deltaTime;
			transform.forward = _velocity;
		}
		if (_fleeBool)
		{
			Flee(_target);
			transform.position -= _velocity * Time.deltaTime;
			transform.forward = -_velocity;
		}
	}

	void Seek(Vector3 target)
	{
		_target = GameManager.instance.PlayerPos.position;
		var desired = target - transform.position;
		desired = desired.normalized * maxSpeed;

		Vector3 steering = desired - _velocity;
		steering = Vector3.ClampMagnitude(steering, maxSpeed);

		AddForce(steering);
	}
	void Flee(Vector3 target)
	{
		_target = GameManager.instance.PlayerPos.position;
		var desired = transform.position - target;
		desired = desired.normalized * maxSpeed;

		Vector3 steering = desired - _velocity;
		steering = Vector3.ClampMagnitude(steering, maxSpeed);

		AddForce(steering);
	}
	public void AddForce(Vector3 dir)
	{
		_velocity += dir;

		if (_velocity.magnitude > maxVelocity)
			_velocity = _velocity.normalized * maxVelocity;
	}

}