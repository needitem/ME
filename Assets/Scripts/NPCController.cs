using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Animator npcAnimator;
    GameObject gAudioDirector;


    // Start is called before the first frame update
    void Start()
    {
        npcAnimator = GetComponent<Animator>();
        gAudioDirector = GameObject.Find("AudioDirector");
    }


    public void Drawing()
    {
        gAudioDirector.GetComponent<AudioDirector>().PlaySound("Sound/throw1");
        npcAnimator.SetTrigger("drawing");
    }
}
