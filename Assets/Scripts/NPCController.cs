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
        audioDirector.SoundPlay("Sound/effect_sound/throw_main");
    }
}
