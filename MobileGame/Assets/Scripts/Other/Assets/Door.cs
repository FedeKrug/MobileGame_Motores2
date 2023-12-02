using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] private bool _isTheLastDoor = false;
	[SerializeField] private Transform _parent;

	public bool IsTheLastDoor { get => _isTheLastDoor; set => _isTheLastDoor = value; }

	public void FinishGame()
	{
		FinishGameScreen.instance.GameOver(true);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("PlayerInteractor")) return;
		if (_isTheLastDoor)
		{
			FinishGame();
		}
	}

	public void GoTroughTheDoor()
	{
		if (_isTheLastDoor) return;
		if (_parent)
		{

		_parent.gameObject.SetActive(false);
		}
	}
}
