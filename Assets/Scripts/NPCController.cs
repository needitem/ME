using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Animator npcAnimator;
    AudioDirector audioDirector;

    void Start()
    {
        npcAnimator = GetComponent<Animator>();
        audioDirector = GetComponent<AudioDirector>();
    }

    public void Drawing()
    {
        npcAnimator.SetTrigger("drawing");

    }
    public void AudioMute(AudioSource audio, bool isOn)
    {
        audio.mute = !isOn; // ��� ���� ���� AudioSource�� ���Ұ� ���� ����
    }
        
    // Update is called once per frame
}