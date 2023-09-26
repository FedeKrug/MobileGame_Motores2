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
			//Debug.Log($"<color=yellow>Mute Volume</color>");
			//Mutear el volumen
			_initVolumeIcon.sprite = _mutedVolumeIcon;
		}
		else
		{
			ActiveVolume();
		}
	}
	private void ActiveVolume()
	{
		//Debug.Log($"<color=yellow>Unmute Volume</color>");
			_initVolumeIcon.sprite = _unmutedVolumeIcon;

		//Si el volumen fue muteado, lo desmutea
	}
}
