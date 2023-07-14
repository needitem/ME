using UnityEngine;

public class KatanaEffect : MonoBehaviour
{
    public static Animator katanaAni;
    void Start()
    {
        katanaAni = GetComponent<Animator>(); // 카타나이펙트 오브젝트의 애니메이터 컴포넌트를 가져온다.
    }

    public static void Punch()
    {
        katanaAni.SetTrigger("punch"); //펀치이펙트 애니메이션 재생
    }

    public static void DoubleAttack()
    {
        katanaAni.SetTrigger("double_attack"); // 더블어택 이펙트 애니메이션 재생
    }

    public static void Attack()
    {
        katanaAni.SetTrigger("attack"); // 공격 이펙트 애니메이션 재생
    }
}