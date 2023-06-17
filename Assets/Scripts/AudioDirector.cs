using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioDirector : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider BgmSlider;
    public Slider SfxSlider;

    AudioSource audioSource;

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

    /*public void AudioControl()
    {
        float sound = audioSlider.value;

        if(sound == -40f)
        {
            masterMixer.SetFloat("BGM", -80);
        }
        else
        {
            masterMixer.SetFloat("BGM", sound);
        }
    }*/

    public void SetBgmVolme()
    {
        // 로그 연산 값 전달
        audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value) * 20);
    }

    public void SetSFXVolme()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(SfxSlider.value) * 20);
    }

    public void SoundMute()
    {
        IsMute = !IsMute;
        audioSource.mute = IsMute;
    }

    public void SoundComtorl()
    {

    }

}