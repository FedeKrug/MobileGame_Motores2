using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody _rb;
	[SerializeField] private float _speed;
	[SerializeField] private Controller _myController;

	private void FixedUpdate()
	{
		_rb.velocity = _myController.MoveDir() * _speed * Time.fixedDeltaTime;
	}

}
