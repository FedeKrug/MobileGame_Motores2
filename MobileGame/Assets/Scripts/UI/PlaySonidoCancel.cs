using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySonidoCancel : MonoBehaviour
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
