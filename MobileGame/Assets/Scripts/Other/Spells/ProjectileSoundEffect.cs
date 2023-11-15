using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSoundEffect : MonoBehaviour
{
	[SerializeField] private AudioClip _soundEffect;
	private AudioSource _aSource;


	private void Start()
	{
		_aSource = GetComponent<AudioSource>();

	}
	public void PlaySoundEffect()
	{
		_aSource.PlayOneShot(_soundEffect);
	}

}
