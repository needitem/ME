using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioDirector : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SoundPlay(string AudioURL)
    {
        audioSource.clip = Resources.Load<AudioClip>(AudioURL);
        audioSource.Play();
    }
}
