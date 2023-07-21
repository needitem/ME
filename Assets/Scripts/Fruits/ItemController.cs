using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemController : MonoBehaviour
{

    [SerializeField] public int itemHp;

    bool executeOnlyOnce = true;
    // Bezier rate
    [Range(0f, 1f)] public float rate;
    // Bezier position
    public Vector2[] controllPosition;
    // End Bezier and Force
    public Rigidbody2D rb;
    Animator itemAnimator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        itemAnimator = GetComponent<Animator>();


    }

    private void FixedUpdate()
    {
        if (gameObject.transform.position.y <= 0.7f)
        // 재료가 맵 아래로 떨어지면 삭제 시키기
        {
            Destroy(gameObject);
        }

        // 선형보간을 계산한 결과값을 프레임과 프레임 사이의 시간을 계속 더해 이동한다.
        rate += Time.deltaTime;
        transform.position = BezierTest(controllPosition[0], controllPosition[1], controllPosition[2], controllPosition[3], rate);


        if (rate >= 1f)
        // 재료가 생성되고 베지어 곡선을 따라가다가, 생성된지 1초가 넘으면 왼쪽 방향으로
        // AddForce를 주기(날아가는 듯한 효과를 위함)
        {
            Vector2 pushForce = Vector2.left * 250.0f;
            rb.AddForce(pushForce);
        }


        if (itemHp == 0) // 재료의 hp가 0이라면
        {
            if (executeOnlyOnce) // 재료 하나당 한번씩만 실행되는 bool형 변수
            {
                itemAnimator.SetTrigger("slice"); // �����̽� �ִϸ��̼� �ο�
          
                Recipe.DecreaseIngredient(this.name);
                executeOnlyOnce = false;
            }
            Vector2 rightForce = Vector2.right * 250.0f;

            // 더이상 왼쪽으로 이동하지 않게 오른쪽 방향으로 똑같이 250만큼 힘을 주어 제자리에 정지된 것 처럼 보이게 만들기
            rb.AddForce(rightForce);

            rb.gravityScale = 15f; // 중력을 부여해 아래로 떨어지게 하기
        }
    }

    // https://www.youtube.com/watch?v=KTEX2L4T4zE
    // 점과 점 사잇값을 추정하기 위하여 직선 거리에 따라 선형적으로 계산하는 방법이다.
    public Vector2 BezierTest(Vector2 P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, float value)
    {
        Vector2 A = Vector2.Lerp(P_1, P_2, value);  //P_1지점과 P_2지점의 선형구간 계산값 : A
        Vector2 B = Vector2.Lerp(P_2, P_3, value);  //P_2지점과 P_3지점의 선형구간 계산값 : B
        Vector2 C = Vector2.Lerp(P_3, P_4, value);  //P_3지점과 P_4지점의 선형구간 계산값 : C

        Vector2 D = Vector2.Lerp(A, B, value);      //A지점과 B지점의 선형구간 계산값 : D
        Vector2 E = Vector2.Lerp(B, C, value);      //B지점과 C지점의 선형구간 계산값 : E

        Vector2 F = Vector2.Lerp(D, E, value);      //D지점과 E지점의 선형구간 계산값 : F
        return F;                                   //위에서 계산한 총 결과값을 F로 반환
    }


}