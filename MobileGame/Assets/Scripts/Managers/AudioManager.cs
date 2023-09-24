using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;
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

	public void SetMasterVolume(float masterVolume)
	{

	}
}
