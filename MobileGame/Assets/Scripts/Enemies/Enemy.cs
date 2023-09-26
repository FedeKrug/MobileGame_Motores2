using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] bool _testBool;
    [SerializeField] float maxVelocity;
    [SerializeField] float maxSpeed;

    Vector3 _velocity;
    Vector3 _target;
    NavMeshAgent _agent;

    private void Start()
    {
        _target = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (_testBool)
        {
            Seek(_target);
            transform.position += _velocity * Time.deltaTime;
            transform.forward = _velocity;
        }
    }

    void Seek(Vector3 target)
    {
        var desired = target - transform.position;
        desired = desired.normalized * maxSpeed;

        Vector3 steering = desired - _velocity;
        steering = Vector3.ClampMagnitude(steering, maxSpeed);

        AddForce(steering);
    }
    void Flee(Vector3 target)
    {
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
