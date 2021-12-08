using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickAudio; // звук при нажатии на кнопку
    public AudioClip hoverAudio; // звук при наведении на кнопку
    public float volume; // громкость

    // воспроизвести звук нажатием на кнопку
    public void PlayAudioClick()
    {
        audioSource.volume = volume;
        audioSource.PlayOneShot(clickAudio);
    }

    // воспроизвести звук наведением на кнопку
    public void PlayAudioHover()
    {
        audioSource.volume = 1;
        audioSource.PlayOneShot(hoverAudio);
    }
}
