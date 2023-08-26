using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    public AudioSource bgmAudioSource;

	private void Start()
	{
		PlayBGM();
	}
	
	private void PlayBGM()
    {
        bgmAudioSource.Play();
    }
	
	private void PlaySFX()
    {

    }
}
