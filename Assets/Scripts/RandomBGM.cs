using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGM : MonoBehaviour
{
    int nRandom;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //만약 adioSource가 Play 중이 아니라면
        if (GetComponent<AudioDirector>().audioSource.isPlaying == false)
        {
            RandomPlay(); //다시 랜덤으로 다음 곡을 재생시킨다.


        }

        // 랜덤으로 1~7의 정수를 반환하여 7개의 BGM중 랜덤으로 재생시키는 함수
        void RandomPlay()
        {
            nRandom = Random.Range(1, 8); // 1~7까지의 난수 발생
                                          //switch case문으로 랜덤값의 bgm을 재생시킨다.
            switch (nRandom)
            {
                case 1:
                    GetComponent<AudioDirector>().SoundPlay("Sound/BGM/Track_1"); 
                    break;
                case 2:
                    GetComponent<AudioDirector>().SoundPlay("Sound/BGM/Track_2");
                    break;
                case 3:
                    GetComponent<AudioDirector>().SoundPlay("Sound/BGM/Track_3");
                    break;
                case 4:
                    GetComponent<AudioDirector>().SoundPlay("Sound/BGM/Track_4");
                    break;
                case 5:
                    GetComponent<AudioDirector>().SoundPlay("Sound/BGM/Track_5");
                    break;
                case 6:
                    GetComponent<AudioDirector>().SoundPlay("Sound/BGM/Track_6");
                    break;
                case 7:
                    GetComponent<AudioDirector>().SoundPlay("Sound/BGM/Track_7");
                    break;
            }
        }
    }
}