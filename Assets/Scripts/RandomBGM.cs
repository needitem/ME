using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGM : MonoBehaviour
{
    AudioSource audioSource;
    AudioDirector audioDirector;

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
            audioDirector.RandomPlay(); // 다시 랜덤으로 bgm을 재생 시킨다.
        }

        if (GameDirector.hp <= 0)
        {
            audioDirector.SoundMute(true); //음소거
        }
    }
}