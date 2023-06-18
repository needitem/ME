using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioDirector : MonoBehaviour
{
    private bool IsMuted = false;

    public AudioMixer audioMixer;   // AudioMixer는 유니티에서 제공하는 오디오를 조절할 수 있는 구간이다.
    public Slider BgmSlider;        // 배경화면 소리를 조절하는 Slider이다.
    public Slider SfxSlider;        // 효과음 소리를 조절하는 Slider이다.
    AudioSource audioSource;        // AudioSource  : 실제로 오디오를 동작하는 행동

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        // 로그 연산 값 전달
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
        if(volume == -40f)
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

        int nRandom = Random.Range(1, 8); 
                                      
        switch (nRandom)
        {
            case 1:
                SoundPlay("Sound/BGM/Track_1");
                break;
            case 2:
                SoundPlay("Sound/BGM/Track_2");
                break;
            case 3:
                SoundPlay("Sound/BGM/Track_3");
                break;
            case 4:
                SoundPlay("Sound/BGM/Track_4");
                break;
            case 5:
                SoundPlay("Sound/BGM/Track_5");
                break;
            case 6:
                SoundPlay("Sound/BGM/Track_6");
                break;
            case 7:
                SoundPlay("Sound/BGM/Track_7");
                break;
        }
    }
}

/*
    audioSource.Play();                                             //재생
    audioSource.Stop();                                             //정지
    audioSource.Pause();                                            //일시정지
    audioSource.UnPause();                                          //일시정지 해제
    audioSource.playOnAwake = true;                                 //씬 시작시 바로 재생
    audioSource.loop = true;                                        //반복 재생
    audioSource.mute = true;                                        //음소거
    audioSource.volume = 1.0f;                                      //볼륨 (0.0 ~ 1.0f)
    audioSource.PlayOneShot(audioClip, 1.0f);                       //특정 클립 한번 만 재생
    audioSource.clip = audioClip;                                   //오디오 클립 교체
    if (audioSource.isPlaying) Debug.Log("오디오 재생중입니다.");     //오디오 재생 여부 확인
*/