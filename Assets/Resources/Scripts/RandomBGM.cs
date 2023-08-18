using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGM : MonoBehaviour
{
    AudioSource audioSource;
    AudioDirector audioDirector;

    public AudioClip[] Music = new AudioClip[7]; // 사용할 BGM

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioDirector = GetComponent<AudioDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying == false) //만약 오디오 소스가 멈춘다면
        {
            // 다시 랜덤으로 bgm을 재생 시킨다.
            audioSource.clip = Music[Random.Range(0, Music.Length)];
            audioSource.Play();
        }

        if (GameDirector.hp <= 0)
        {
            audioDirector.SoundMute(true); //음소거
        }
    }
}