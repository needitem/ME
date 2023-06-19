using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioDirector : MonoBehaviour
{
    private bool IsMuted = false; // 음소거 여부

    public AudioMixer audioMixer; // 오디오 믹서

    public Slider BgmSlider; // 배경음 슬라이더
    public Slider SfxSlider; // 효과음 슬라이더

    public AudioSource audioSource; // 오디오 소스

    private Dictionary<int, AudioClip> audioClips = new Dictionary<int, AudioClip>(); // 오디오 클립들

    void Start()
    {
        LoadAudioClips(); // 오디오 클립들을 불러온다.
        
        audioSource = GetComponent<AudioSource>(); // 오디오 소스를 가져온다.

    }

    private void LoadAudioClips() // 오디오 클립들을 불러온다.
    {
        for (int i = 0; i <= 7; i++) 
        {
            string audioPath = string.Format("Sound/BGM/Track_{0}", i); // 오디오 클립의 경로
            AudioClip audioClip = Resources.Load<AudioClip>(audioPath); // 오디오 클립을 불러온다.
            audioClips[i] = audioClip; // 오디오 클립을 딕셔너리에 넣는다.
        }
    }
    public void SoundPlay(string AudioURL)
    {
        audioSource.clip = Resources.Load<AudioClip>(AudioURL); // 오디오 클립을 불러온다.
        audioSource.Play(); // 오디오를 재생한다.
    }

    public void SoundMute(bool IsMute)
    {
        audioSource.mute = IsMute; // 음소거 여부를 설정한다.
    }


    public void SoundMute()
    {
        IsMuted = !IsMuted; // 음소거 여부를 설정한다.
        audioSource.mute = IsMuted; // 음소거 여부를 설정한다.
    }

    public void SetBgmVolme()
    {
        float volume = BgmSlider.value; // 슬라이더의 값을 가져온다.
        if (volume == -40f) // 슬라이더의 값이 -40이면
        {
            audioMixer.SetFloat("BGM", -80); // 믹서의 볼륨을 -80으로 설정한다.
        }
        else
        {
            audioMixer.SetFloat("BGM", volume); // 믹서의 볼륨을 설정한다.
        }
    }

    public void SetSfxVolme() // 효과음 볼륨을 설정한다.
    {
        float volume = SfxSlider.value; // 슬라이더의 값을 가져온다.
        if(volume == -40f) // 슬라이더의 값이 -40이면
        {
            audioMixer.SetFloat("SFX", -80); // 믹서의 볼륨을 -80으로 설정한다.
        }
        else
        {
            audioMixer.SetFloat("SFX", volume); // 믹서의 볼륨을 설정한다.
        }
    }
    public void RandomPlay() // 랜덤으로 오디오를 재생한다.
    {
        int nRandom = Random.Range(0, 8); // 0~7까지의 랜덤 값을 가져온다.
        audioSource.clip = audioClips[nRandom]; // 오디오 클립을 가져온다.
        audioSource.Play(); // 오디오를 재생한다.
    }

}