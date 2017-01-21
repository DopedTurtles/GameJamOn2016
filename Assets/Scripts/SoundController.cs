using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class SoundController : MonoBehaviour {

    //Variables propias de SoundController
    public AudioSource backgroundMusic;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

   public void ReproducirAudio()
    {
        backgroundMusic.Play();
    }

    public void cambiarAudioClip(string resourceNombre)
    {
        backgroundMusic.clip = GameObject.Instantiate((AudioClip)Resources.Load(resourceNombre));
    }
   public void PararAudio()
    {
        backgroundMusic.Stop();
    }

    public void ActivarBucle(bool nuevoEstado)
    {
        backgroundMusic.loop = nuevoEstado;
    }

}
