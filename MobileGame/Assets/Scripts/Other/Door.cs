using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] private bool _isTheLastDoor = false;
	[SerializeField] private Transform _parent;


	public void FinishGame()
	{
		FinishGameScreen.instance.GameOver(true);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PlayerInteractor") && _isTheLastDoor)
		{
			FinishGame();
		}
	}

	public void GoTroughTheDoor()
	{
		if (_isTheLastDoor) return;
		_parent.gameObject.SetActive(false);
	}
}
