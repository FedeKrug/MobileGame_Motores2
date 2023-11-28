using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class VolumeSettings : MonoBehaviour
{
	[SerializeField] private AudioSource _source;
	[SerializeField] private AudioMixer _mixer;
	[SerializeField] private PlayerSettings _playerPrefSettings;
	public Slider masterVolumeSlider, musicVolumeSlider, sfxVolumeSlider;

	public void SetMasterVolume()
	{
		float volume = masterVolumeSlider.value;
		_mixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
		_playerPrefSettings.SetMasterVolumePref();
	}
	public void SetMusicVolume()
	{
		float volume = musicVolumeSlider.value;
		_mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
		_playerPrefSettings.SetMusicVolumePref();
	}
	public void SetSfxVolume()
	{
		float volume = sfxVolumeSlider.value;
		_mixer.SetFloat("SfxVolume", Mathf.Log10(PlayerPrefs.GetFloat("VolumenEfectos")) * 20);
		_playerPrefSettings.SetSFXVolumePref();
	}

	public void MuteAudio()
	{
		sfxVolumeSlider.value = 0.00001f;
		 musicVolumeSlider.value = 0.00001f;
		masterVolumeSlider.value = 0.00001f;

		_playerPrefSettings.SetMasterVolumePref();
	}


	public void PlayAudio(AudioClip clip)
	{
		if (_source.clip == clip) return;
		_source.Stop();
		_source.clip = clip;
		_source.Play();
	}
	 
}