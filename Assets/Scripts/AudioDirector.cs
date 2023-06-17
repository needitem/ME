using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioDirector : MonoBehaviour
{
   public  AudioSource audioSource;

    private bool IsMute = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SoundPlay(string AudioURL)
    {
        audioSource.clip = Resources.Load<AudioClip>(AudioURL);
        audioSource.Play();
    }

    public void SoundMute()
    {
        IsMute = !IsMute;
        audioSource.mute = IsMute;
    }
}
