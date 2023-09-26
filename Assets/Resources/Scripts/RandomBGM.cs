using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGM : MonoBehaviour
{
    GameStart_FadeOut gs;
    AudioSource audioSource;
    AudioDirector audioDirector;

    public AudioClip[] Music = new AudioClip[7]; // ����� BGM
    public int currentBGMIndex = 0;

    public GameObject Menu_panel;


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
            if (Menu_panel.activeSelf)
            {
                StopBGM();
            }
            else
            {
                PlayNextBGM();
            }
            // ������� bgm ���, ������ ��� bgm�� ������ϸ� ����� bgm�� ����
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

        currentBGMIndex = Random.Range(0, Music.Length);
        Generator.song = currentBGMIndex;
        Generator.index = 0;
        Generator.deltatime = 0.0f;
        audioSource.clip = Music[currentBGMIndex];
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Pause(); 
    }
    public void PlayBGM()
    {
        audioSource.UnPause();
    }

    }