using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
	[SerializeField] private AudioSource _source;
	[SerializeField] private AudioMixer _mixer;
	public Slider masterVolumeSlider, musicVolumeSlider, sfxVolumeSlider;


	public void SetMasterVolume()
	{
		float volume = masterVolumeSlider.value;
		_mixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
	}
	public void SetMusicVolume()
	{
		float volume = musicVolumeSlider.value;
		_mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
	}
	public void SetSfxVolume()
	{
		float volume = sfxVolumeSlider.value;
		_mixer.SetFloat("SfxVolume", Mathf.Log10(volume) * 20);
	}

	public void MuteAudio()
	{
		sfxVolumeSlider.value = 0.00001f;
		 musicVolumeSlider.value = 0.00001f;
		masterVolumeSlider.value = 0.00001f;
	}


	public void PlayAudio(AudioClip clip)
	{
		if (_source.clip == clip) return;
		_source.Stop();
		_source.clip = clip;
		_source.Play();
	}

}