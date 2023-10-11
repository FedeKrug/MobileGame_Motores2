using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Chest : MonoBehaviour, Interactable
{
	[SerializeField] private int _coinsAmount;
	[SerializeField] private bool _isOpen;
	private Animation _anim;

	private void Start()
	{
		_anim = GetComponentInChildren<Animation>();
	}
	public void Interact()
	{
		if (_isOpen)
		{
			return;
		}
		_anim.Play();
		gameObject.layer = 0;
		UIManager.instance.TakeCoins(_coinsAmount);
		_isOpen = true;
	}
}
