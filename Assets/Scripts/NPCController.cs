using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Animator npcAnimator;
    // Start is called before the first frame update
    void Start()
    {
        npcAnimator = GetComponent<Animator>();
    }


    public void Drawing()
    {
        npcAnimator.SetTrigger("drawing");
    }
}
