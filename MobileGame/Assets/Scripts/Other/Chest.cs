using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Chest : MonoBehaviour, Interactable
{

	[SerializeField] private int _coinsAmount;
	[SerializeField] private bool _isOpen;
	[SerializeField] private AudioClip _soundEffect;
	private Animation _anim;
	private AudioSource _aSource;
	private void Start()
	{
		_anim = GetComponentInChildren<Animation>();
		_aSource = GetComponent<AudioSource>();
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
		_aSource.PlayOneShot(_soundEffect);
	}
}
