using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JoyController : Controller
{
	Vector3 _dir;
	Vector3 _initPos;
	

	public override Vector3 MoveDir()
	{
		return _dir;
	}
}
