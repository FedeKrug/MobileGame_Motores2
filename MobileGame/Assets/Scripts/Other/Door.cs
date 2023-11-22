using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] private bool _isTheLastDoor = false;
	private Transform _parent;
	private void Start()
	{
		_parent = GetComponentInParent<Transform>();
	}

	public void FinishGame()
	{
		FinishGameScreen.instance.GameOver(true);
	}

	public void GoTroughTheDoor()
	{
		if (_isTheLastDoor)
		{
			FinishGame();

		}
		else
		{
			_parent.gameObject.SetActive(false);
		}
	}
}
