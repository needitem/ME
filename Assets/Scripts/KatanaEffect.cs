using UnityEngine;

public class KatanaEffect : MonoBehaviour
{
    public static Animator katanaAni;
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

    public static void Attack()
    {
        katanaAni.SetTrigger("attack");
    }
}