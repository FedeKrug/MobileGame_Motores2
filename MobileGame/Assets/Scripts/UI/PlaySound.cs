using UnityEngine;

public class PlaySound : MonoBehaviour
{
	[SerializeField] private AudioSource sonidoBoton;


	public void Play()
	{
		sonidoBoton.Play();
	}
}
