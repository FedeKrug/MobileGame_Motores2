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
			Debug.Log("Chest has been already open");
			return;
		}
		//TODO: Utilizar la animacion del chest para cuando se abre.
		_anim.Play();
		UIManager.instance.TakeCoins(_coinsAmount);
		Debug.Log("The chest is open");
	}
}
