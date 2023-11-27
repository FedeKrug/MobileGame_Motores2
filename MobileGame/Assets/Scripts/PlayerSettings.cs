using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private Slider masterVol;
    [SerializeField] private Slider musicVol;
    [SerializeField] private Slider SFXVol;
    void Start()
    {
        masterVol.value = PlayerPrefs.GetFloat("VolumenMaestro");
        musicVol.value = PlayerPrefs.GetFloat("VolumenMusica");
        SFXVol.value = PlayerPrefs.GetFloat("VolumenEfectos");
    }

    public void SetMasterVolumePref()
    {
        PlayerPrefs.SetFloat("VolumenMaestro", masterVol.value);
    }

    public void SetMusicVolumePref()
    {
        PlayerPrefs.SetFloat("VolumenMusica", musicVol.value);
    }

    public void SetSFXVolumePref()
    {
        PlayerPrefs.SetFloat("VolumenEfectos", SFXVol.value);
    }
}
