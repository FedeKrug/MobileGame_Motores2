using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody _rb;
	[SerializeField] private Controller _myController;
	[SerializeField] PlayerShootingTest _shootingRef;

	
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
		//Debug.Log($"<color=yellow>{_rb.velocity.x}, {_rb.velocity.z} es rb.velocity del player.</color>");
		//if ((_rb.velocity.x != 0 || _rb.velocity.z != 0))
		//{
		//		//El player se mueve
		//		_shootingRef.Moving = true;
		//}
		//else _shootingRef.Moving = false;

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
