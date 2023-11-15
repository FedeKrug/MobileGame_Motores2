using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour, Collectable
{
	[SerializeField] private int _score;
	[SerializeField] private AudioClip _soundEffect;
	private AudioSource _aSource;

	private void Start()
	{
		_aSource = GetComponent<AudioSource>();	
	}
	public void Collect()
	{
		UIManager.instance.TakeCoins(_score);
		StartCoroutine(useCoinEffect());
	}
	IEnumerator useCoinEffect()
	{

		_aSource.PlayOneShot(_soundEffect);
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
		while (_aSource.isPlaying) { 
		yield return null;
		}
		Destroy(gameObject);
	}
}
