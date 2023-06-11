using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaEffect : MonoBehaviour
{
    Animator katanaAni;
    void Start()
    {
        katanaAni = GetComponent<Animator>();
    }

    public static void Punch()
    {
        katanaAni.SetTrigger("punch");
    }

    public static void DoubleAttack()
    {
        katanaAni.SetTrigger("double_attack");
    }

    public static void attack()
    {
        katanaAni.SetTrigger("attack");
    }
}
