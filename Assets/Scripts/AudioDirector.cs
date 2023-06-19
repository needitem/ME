using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioDirector : MonoBehaviour
{
    private bool IsMuted = false;

    public AudioMixer audioMixer;

    public Slider BgmSlider;  // 배경 음악 슬라이더
    public Slider SfxSlider;  // 효과음 슬라이더

    public AudioSource audioSource;

    private Dictionary<int, AudioClip> audioClips = new Dictionary<int, AudioClip>();

    void Start()
    {
        LoadAudioClips();

        audioSource = GetComponent<AudioSource>();
    }

    private void LoadAudioClips()
    {
        for (int i = 0; i <= 7; i++)
        {
            string audioPath = string.Format("Sound/BGM/Track_{0}", i);
            AudioClip audioClip = Resources.Load<AudioClip>(audioPath);
            audioClips[i] = audioClip;
        }
    }

    public void SoundPlay(string AudioURL)
    {
        audioSource.clip = Resources.Load<AudioClip>(AudioURL);
        audioSource.Play();
    }

    public void SoundMute(bool IsMute)
    {
        audioSource.mute = IsMute;
    }

    public void SoundMute()
    {
        IsMuted = !IsMuted;
        audioSource.mute = IsMuted;
    }

    public void SetBgmVolme()
    {
        float volume = BgmSlider.value;
        if (volume == -40f)
        {
            audioMixer.SetFloat("BGM", -80);
        }
        else
        {
            audioMixer.SetFloat("BGM", volume);
        }
    }

    public void SetSfxVolme()
    {
        float volume = SfxSlider.value;
        if (volume == -40f)
        {
            audioMixer.SetFloat("SFX", -80);
        }
        else
        {
            audioMixer.SetFloat("SFX", volume);
        }
    }

    public void RandomPlay()
    {
        int nRandom = Random.Range(0, 8);
        audioSource.clip = audioClips[nRandom];
        audioSource.Play();
    }
}
