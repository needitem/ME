using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioDirector : MonoBehaviour
{
    private bool IsMuted = false;

    public AudioMixer audioMixer;

    public Slider BgmSlider;
    public Slider SfxSlider;

    public AudioSource audioSource;


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
        // ë¡œê·¸ ?—°?‚° ê°? ? „?‹¬
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