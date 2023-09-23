using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraController : MonoBehaviour
{
	private Transform _target;

	//TODO: optimizar esto para que sea _limitOffsetHorizontal, y _limitOffsetVertical;
	[SerializeField] private float _maxLimitOffset, _minLimitOffset, _leftOffset, _rightOffset, _initialOffset = -7;



	private void Start()
	{
		_target = PlayerManager.instance.PlayerPos;
	}


	private void LateUpdate()
	{
		if (_target.position.z > _maxLimitOffset || _target.position.z < _minLimitOffset || _target.position.x <= _leftOffset || _target.position.x >= _rightOffset)
		{
			StartMovingVertical();
			StartMovingHorizontal();
		}
		//if ()
		//{
		//}
	}

	private void StartMovingVertical()
	{
		//La camara se mueve cuando el player pasa cierto limite
		Vector3 fixedPos = new Vector3(transform.position.x, transform.position.y, _target.position.z + _initialOffset);

		transform.position = fixedPos;
	}
	private void StartMovingHorizontal()
	{
		//La camara se mueve cuando el player pasa cierto limite
		Vector3 fixedPos = new Vector3(_target.position.x, transform.position.y, transform.position.z);

		transform.position = fixedPos;
	}
}
