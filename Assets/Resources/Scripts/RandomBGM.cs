using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGM : MonoBehaviour
{
    GameStart_FadeOut gs;
    AudioSource audioSource;
    AudioDirector audioDirector;

    public AudioClip[] Music = new AudioClip[7]; // ����� BGM
    public static int currentBGMIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //gs = GetComponent<GameStart_FadeOut>();
        audioSource = GetComponent<AudioSource>();
        audioDirector = GetComponent<AudioDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying == false && GameStart_FadeOut.isMessageWait == false)
        {
            PlayNextBGM();
        }

        if (GameDirector.hp <= 0)
        {
            audioDirector.SoundMute(true); //���Ұ�
        }
    }

    void PlayNextBGM()
    {
        // ���� BGM �ε��� ����
        currentBGMIndex = (currentBGMIndex + 1) % Music.Length;

        // ������ BGM ���
        audioSource.clip = Music[currentBGMIndex];
        audioSource.Play();
    }

    void PlayRandomBGM()
    {
        currentBGMIndex = Random.Range(0, Music.Length);
        Generator.index = 0;
        audioSource.clip = Music[currentBGMIndex];
        audioSource.Play();
    }
}