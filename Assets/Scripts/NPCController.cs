using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Animator npcAnimator;

    void Start()
    {
        npcAnimator = GetComponent<Animator>();
    }


    public void Drawing()
    {
        npcAnimator.SetTrigger("drawing");
    }
}
