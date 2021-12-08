using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickAudio; // ���� ��� ������� �� ������
    public AudioClip hoverAudio; // ���� ��� ��������� �� ������
    public float volume; // ���������

    // ������������� ���� �������� �� ������
    public void PlayAudioClick()
    {
        audioSource.volume = volume;
        audioSource.PlayOneShot(clickAudio);
    }

    // ������������� ���� ���������� �� ������
    public void PlayAudioHover()
    {
        audioSource.volume = 1;
        audioSource.PlayOneShot(hoverAudio);
    }
}
