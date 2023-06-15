using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    //수정
    public void PlaySound(string AudioURL)
    {
        // 이거 함수 안에 넣어 놨는데 스크립트 밖으로 빼서 써도 상관없을듯함.
        AudioSource audioSource = GetComponent<AudioSource>();

        AudioClip audioClip = Resources.Load<AudioClip>(AudioURL);
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySound("Sound/throw1");
        }
      
        /*
        audioSource.Play(); //재생

        audioSource.Stop(); //정지

        audioSource.Pause(); //일시정지

        audioSource.UnPause(); //일시정지 해제

        audioSource.playOnAwake = true; //씬 시작시 바로 재생

        audioSource.loop = true; //반복 재생

        audioSource.mute = true; //음소거

        audioSource.volume = 1.0f; //볼륨 (0.0 ~ 1.0f)

        audioSource.PlayOneShot(audioClip, 1.0f); //특정 클립 한번 만 재생

        audioSource.clip = audioClip; //오디오 클립 교체
        */
    }
}
