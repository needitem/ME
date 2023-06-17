using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Animator npcAnimator;
    AudioDirector NPCAudio;

    void Start()
    {
        npcAnimator = GetComponent<Animator>();
        NPCAudio = GetComponent<AudioDirector>();
    }

    public void Drawing()
    {
        npcAnimator.SetTrigger("drawing");
/*        if (Generator.itemHp == 2)
        {
            NPCAudio.SoundNPC("effect_sound/throw_main");
        }
        else
        {
            NPCAudio.SoundNPC("effect_sound/throw_sub");
        }*/
    }
}
