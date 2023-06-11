using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class katana_effect : MonoBehaviour
{
    Animator katanaAni;
    void Start()
    {
        katanaAni = GetComponent<Animator>();
    }

    public static void Hit()
    {
        katanaAni.SetTrigger("attack");
    }

    public static void DoubleHit()
    {
        katanaAni.SetTrigger("double_attack");
    }

    public static void Punch()
    {
        katanaAni.SetTrigger("punch");
    }
}
