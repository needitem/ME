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
                itemAnimator.SetTrigger("slice"); // 슬라이스 애니메이션 부여
          
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
    public Vector2 BezierTest(Vector2 P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, float value)
    {
        Vector2 A = Vector2.Lerp(P_1, P_2, value);
        Vector2 B = Vector2.Lerp(P_2, P_3, value);
        Vector2 C = Vector2.Lerp(P_3, P_4, value);

        Vector2 D = Vector2.Lerp(A, B, value);
        Vector2 E = Vector2.Lerp(B, C, value);

        Vector2 F = Vector2.Lerp(D, E, value);
        return F;
    }


}