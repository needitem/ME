using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Animator npcAnimator;
    AudioDirector audioDirector;

    void Start()
    {
        npcAnimator = GetComponent<Animator>(); //npc오브젝트의 애니메이션 컴포넌트를 가져온다.
        audioDirector = GetComponent<AudioDirector>();
    }

    public void Drawing()
    {
        npcAnimator.SetTrigger("drawing"); //던지는 애니메이션 재생 -> 제너레이터에서 프리팹이 생성 될 때마다 호출시킨다.

    }
    public void AudioMute(AudioSource audio, bool isOn)
    {
        audio.mute = !isOn; // 음소거
    }

    // Update is called once per frame
}