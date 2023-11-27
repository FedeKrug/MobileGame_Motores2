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

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PlayerInteractor") && _isTheLastDoor)
		{
			FinishGame();
		}
	}

	public void GoTroughTheDoor()
	{
		if (!_isTheLastDoor)
		{
		_parent.gameObject.SetActive(false);

		}

	}
}
