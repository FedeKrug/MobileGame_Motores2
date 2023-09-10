using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody _rb;
	[SerializeField] private Controller _myController;
    private float _speed;

	private void Start()
	{
        _speed = PlayerManager.instance.PlayerStats.movementSpeed;
	}
	private void FixedUpdate()
	{
		_rb.velocity = _myController.MoveDir() * _speed * Time.fixedDeltaTime;
        Rotate();
	}
    private void Update()
    {
		
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
