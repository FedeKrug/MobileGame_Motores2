using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
   
    [SerializeField] private VolumeSettings _volume;


	void Start()
    {
        _volume.masterVolumeSlider.value = PlayerPrefs.GetFloat("VolumenMaestro");
        _volume.musicVolumeSlider.value = PlayerPrefs.GetFloat("VolumenMusica");
        _volume.sfxVolumeSlider.value = PlayerPrefs.GetFloat("VolumenEfectos");
    }

    public void SetMasterVolumePref()
    {
        PlayerPrefs.SetFloat("VolumenMaestro", _volume.masterVolumeSlider.value);
    }

    public void SetMusicVolumePref()
    {
        PlayerPrefs.SetFloat("VolumenMusica", _volume.musicVolumeSlider.value);
    }

    public void SetSFXVolumePref()
    {
        PlayerPrefs.SetFloat("VolumenEfectos", _volume.sfxVolumeSlider.value);
    }
}
