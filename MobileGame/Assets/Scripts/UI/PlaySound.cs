using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource sonidoBoton;

    private void Start()
    {
        sonidoBoton = GetComponent<AudioSource>();
    }
    public void Play()
    {
        sonidoBoton.Play();
    }
}
