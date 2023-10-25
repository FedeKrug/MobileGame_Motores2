using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEditor.iOS;

public class VolumeSettings : MonoBehaviour
{
	[SerializeField] private AudioSource _source;
	[SerializeField] private AudioMixer _mixer;
	[SerializeField] private Slider _masterVolumeSlider, _musicVolumeSlider, _sfxVolumeSlider;

	public void SetMasterVolume()
	{
		float volume = _masterVolumeSlider.value;
		_mixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
	}
	public void SetMusicVolume()
	{
		float volume = _musicVolumeSlider.value;
		_mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
	}
	public void SetSfxVolume()
	{
		float volume = _sfxVolumeSlider.value;
		_mixer.SetFloat("SfxVolume", Mathf.Log10(volume) * 20);
	}


	public void PlayAudio(AudioClip clip)
	{
		if (_source.clip == clip) return;
		_source.Stop();
		_source.clip = clip;
		_source.Play();
	}

}