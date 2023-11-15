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
			_initVolumeIcon.sprite = _unmutedVolumeIcon;
	
	
	}

	private void MuteVolume()
	{
		_volume.MuteAudio();
		_initVolumeIcon.sprite = _mutedVolumeIcon;
	}
}
