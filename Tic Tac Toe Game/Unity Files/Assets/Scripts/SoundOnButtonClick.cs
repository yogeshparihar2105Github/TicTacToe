using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnButtonClick : MonoBehaviour
{
    public AudioClip audioClip;    
    public AudioSource audioSource;

    public void PlayTheClickSound()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
