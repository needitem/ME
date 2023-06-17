using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioDirector : MonoBehaviour
{
    AudioSource audioSource;
    public Slider volumeSlider;
    public Toggle audioToggle;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }
    //수정
    public void PlaySound(string AudioURL)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(AudioURL);
        audioSource.clip = audioClip;
        audioSource.Play();
        audioToggle.onValueChanged.AddListener(OnToggleChanged); // 토글 값이 변경될 때마다 OnToggleChanged 호출
    }
    public void OnVolumeChanged(float value)
    {
        audioSource.volume = value; // 슬라이더 값에 따라 AudioSource의 volume 조절
    }

    public void OnToggleChanged(bool isOn)
    {
        audioSource.mute = !isOn; // 토글 값에 따라 AudioSource의 음소거 여부 설정
    }

    // Update is called once per frame
    void Update()
    {


/*        audioSource.Play(); //재생

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
