using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioDirector : MonoBehaviour
{
    public GameObject gPlayer;
    public GameObject gNPC;

    public AudioSource aPlayerSound;
    public AudioSource aNPCSound;
    //public AudioSource audioSource;

    private static bool isMuted = false;


    /*    public Slider volumeSlider;
        public Toggle audioToggle;*/

    // Start is called before the first frame update
    void Start()
    {
        gPlayer = GameObject.Find("Player");
        gNPC = GameObject.Find("NPC");

        aPlayerSound = gPlayer.GetComponent<AudioSource>();
        aNPCSound = gNPC.GetComponent<AudioSource>();
        //audioSource = GetComponent<AudioSource>();

        /*volumeSlider.onValueChanged.AddListener(OnVolumeChanged);*/
    }

    public void SoundPlay(string AudioURL)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(AudioURL);
        aPlayerSound.clip = audioClip;
        aPlayerSound.Play();
    }

    public void SoundNPC(string AudioURL)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(AudioURL);
        aNPCSound.clip = audioClip;
        aNPCSound.Play();
    }
    public void EffectSoundMute() // 여기서 두개의 오브젝트가 오류가 생기는데 해결책이 있을까?
    {
        isMuted = !isMuted;
        aPlayerSound.mute = isMuted;
        aNPCSound.mute = isMuted;
    }

    /*public void OnVolumeChanged(float value)
    {
        audioSource.volume = value; // 슬라이더 값에 따라 AudioSource의 volume 조절
    }*/


    // Update is called once per frame
    void Update()
    {
        /*      audioSource.Play(); //재생

                audioSource.Stop(); //정지

                audioSource.Pause(); //일시정지

                audioSource.UnPause(); //일시정지 해제

                audioSource.playOnAwake = true; //씬 시작시 바로 재생

                audioSource.loop = true; //반복 재생

                audioSource.mute = true; //음소거

                audioSource.volume = 1.0f; //볼륨 (0.0 ~ 1.0f)

                audioSource.PlayOneShot(audioClip, 1.0f); //특정 클립 한번 만 재생

                audioSource.clip = audioClip; //오디오 클립 교체*/

    }
}
