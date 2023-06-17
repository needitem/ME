using System.Collections;
using UnityEngine;


public class Effect : MonoBehaviour
{
    // https://www.youtube.com/watch?v=lty5EXXkFRQ&t=14s //참고
    

    private static Effect et;
    // 정적 함수에선 StartCoroutine 함수를 사용할 수 없다
    // 하지만 자기 자신의 인스턴스를 만들어 그 인스턴스를 통해 StartCoroutine 함수를 실행시킨다면,
    // 정적 함수에서도 StartCoroutine 함수 호출이 가능하다.
    private void Awake()
    {
        et = this;
    }

    public static void Apply(GameObject target)
    {
        et.StartCoroutine(ScaleTarget(target));
        // 코루틴은 외부함수에서 호출할 수 없지만
        // StartCoroutine 함수는 받고 있는 인스턴스를 통해 호출이 가능하기 때문에
        // 대신 호출 받아줄 메서드를 작성하여 호출을 시도한다면 가능하다.
        // Ex) StartCoroutine 호출이 안되지만, et.StartCoroutine 함수는 호출 가능
    }

    // 튕겨내기 시 효과 주기
    public static IEnumerator ScaleTarget(GameObject target)
    {
        float currentScale = 3.5f; // 크기를 키우거나 줄이기 위한 변수
        target.GetComponent<Collider2D>().enabled = false;
        // 크기가 커져 캐릭터와 부딪히는걸 방지하기 위해 콜라이더 비활성화

        Vector2 rightForce = Vector2.right * 750.0f;
        target.GetComponent<Rigidbody2D>().AddForce(rightForce); // 재료를 오른쪽으로 약간 날려보내는 듯한 효과를 내기위해 오른쪽 방향으로 AddForce를 주기
       
        target.transform.localScale = new Vector3(currentScale, currentScale, 1f); // 재료의 크기를 키우거나 줄이기 위한 코드

        yield return new WaitForSeconds(0.1f); // 0.1 초 후

        if (currentScale >= 3.5) // 크기가 3.5 이상이라면
        {
            Destroy(target); // 재료 삭제
        }

    }
}
