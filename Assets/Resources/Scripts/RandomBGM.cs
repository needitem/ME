using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGM : MonoBehaviour
{
    GameStart_FadeOut gs;
    AudioSource audioSource;
    AudioDirector audioDirector;

    public AudioClip[] Music = new AudioClip[7]; // ����� BGM
    static public int currentBGMIndex;

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
        if (audioSource.isPlaying == false && GameStart_FadeOut.isMessageWait == false)//gs.isMessageWait == false) //���� ����� �ҽ��� ����ٸ�
        {
            // ������� bgm ���, ������ ��� bgm�� ������ϸ� ����� bgm�� ����
            PlayNextBGM();
        }

        if (GameDirector.hp <= 0)
        {
            audioDirector.SoundMute(true); //���Ұ�
        }
    }

    void PlayNextBGM()
    {
        currentBGMIndex = Random.Range(0, Music.Length);
        Generator.song = currentBGMIndex;
        Generator.index = 0;
        audioSource.clip = Music[currentBGMIndex];
        audioSource.Play();
    }
}