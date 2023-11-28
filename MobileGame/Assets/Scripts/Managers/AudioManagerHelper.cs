using UnityEngine;
using UnityEngine.UI;
public class AudioManagerHelper : MonoBehaviour
{
	/// <summary>
	/// Una clase que tengo para complementar al AudioManager de mi libreria
	/// </summary>
	public static AudioManagerHelper instance;


	[SerializeField] private Sprite _unmutedVolumeIcon, _mutedVolumeIcon;
	[SerializeField] private Image _initVolumeIcon;
	[SerializeField] private VolumeSettings _volume;

	public bool mutedVolume;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void ChangeMutedVolumeState()
	{


		mutedVolume = !mutedVolume;
		if (mutedVolume)
		{
			MuteVolume();
		}
		else
		{
			ActiveVolume();
		}
	}
	private void ActiveVolume()
	{
		_volume.masterVolumeSlider.value = PlayerPrefs.GetFloat("VolumenMaestro");
		_volume.musicVolumeSlider.value = PlayerPrefs.GetFloat("VolumenMusica");
		_volume.sfxVolumeSlider.value = PlayerPrefs.GetFloat("VolumenEfectos");

		_initVolumeIcon.sprite = _unmutedVolumeIcon;
	}

	private void MuteVolume()
	{
		//_masterVolumeHelper = _volume.masterVolumeSlider.value;
		//_musicVolumeHelper = _volume.musicVolumeSlider.value;
		//_sfxVolumeHelper = _volume.sfxVolumeSlider.value;

		_volume.MuteAudio();
		_initVolumeIcon.sprite = _mutedVolumeIcon;
	}

	
}
