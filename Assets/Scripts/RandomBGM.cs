using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGM : MonoBehaviour
{
    AudioSource audioSource;
    AudioDirector audioDirector;

    public AudioClip[] Music = new AudioClip[7]; // 사용할 BGM
    public int currentBGMIndex = 0;

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
            // 순서대로 bgm 출력, 문제점 모든 bgm을 다출력하면 출력할 bgm이 없음
            PlayNextBGM();
        }

        if (GameDirector.hp <= 0)
        {
            audioDirector.SoundMute(true); //음소거
        }
    }

    void PlayNextBGM()
    {
        // 다음 BGM 인덱스 설정
        currentBGMIndex = (currentBGMIndex + 1) % Music.Length;

        // 설정된 BGM 재생
        audioSource.clip = Music[currentBGMIndex];
        audioSource.Play();
    }
}