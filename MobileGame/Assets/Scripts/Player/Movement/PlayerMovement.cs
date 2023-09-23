using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody _rb;
	[SerializeField] private Controller _myController;
	[SerializeField] PlayerShootingTest _shootingRef;

	[SerializeField] EnemyCounter _enemyCounterRef;
	private float _speed;

	private void Start()
	{
		_speed = PlayerManager.instance.PlayerStats.movementSpeed;
	}
	private void FixedUpdate()
	{
		_rb.velocity = _myController.MoveDir() * _speed * Time.fixedDeltaTime;
		// Debug.Log($"<color=yellow> Con el color puedo cambiar el color de la fuente. </color>");
		Rotate();
	}

	private void Update()
	{
		if ((_rb.velocity.x != 0 || _rb.velocity.y != 0))
		{
			if (_enemyCounterRef.enemiesInLevel)
			{
				//El player se mueve
				_shootingRef.Moving = true;
			}
			else _shootingRef.Moving = false;
		}
		else _shootingRef.Moving = false;

		if (Input.GetKeyDown(KeyCode.Return))
		{
			Debug.Log("Back");
		}

		if (Input.GetKeyDown(KeyCode.Menu))
		{
			Debug.Log("Menu");
		}
	}

	private void Rotate()
	{
		transform.forward += _myController.MoveDir();
	}
}
