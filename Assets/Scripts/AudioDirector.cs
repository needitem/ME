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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource = GetComponent<AudioSource>();
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


}
