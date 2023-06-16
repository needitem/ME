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
        if (gameObject.transform.position.y <= 0.7f) // 재료가 맵 아래로 떨어지면 삭제 시키기
        {
            Destroy(gameObject);
        }

        rate += Time.deltaTime;
        transform.position = BezierTest(controllPosition[0], controllPosition[1], controllPosition[2], controllPosition[3], rate);


        if (rate >= 1f) // 재료가 생성되고 베지어 곡선을 따라가다, 생성된지 1초가 넘으면 왼쪽 방향으로 AddForce 주기(날아가는 듯한 효과)
        {
            Vector2 pushForce = Vector2.left * 250.0f;
            rb.AddForce(pushForce);
        }


        if (itemHp <= 0) // 어택으로 인해 음식의 hp가 0이 될시 실행시키는 if문
        {
            if (executeOnlyOnce) // 재료 하나당 한번씩만 실행되는 bool형 변수
            {
                itemAnimator.SetTrigger("slice"); // 슬라이스 애니메이션 부여
                rb.MovePosition(new Vector2(4f, 3f)); // 재료를 해당 위치로 이동시키기
                executeOnlyOnce = false;
            }
            Vector2 rightForce = Vector2.right * 250.0f; 
            rb.AddForce(rightForce); // 더이상 왼쪽으로 이동하지 않게 오른쪽 방향으로 똑같이 250만큼 힘을 주어 제자리에 정지된 것 처럼 보이게 만들기
            rb.gravityScale = 15f; // 그 후 중력을 부여해 아래로 떨어지게 하기
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

// Bezier graphic area
[CanEditMultipleObjects]
[CustomEditor(typeof(ItemController))]
public class Test_Editor : Editor
{
    private void OnSceneGUI()
    {
        // Current Object Reference
        ItemController Generator = (ItemController)target;

        // Object Control 
        Generator.controllPosition[0] = Handles.PositionHandle(Generator.controllPosition[0], Quaternion.identity);
        Generator.controllPosition[1] = Handles.PositionHandle(Generator.controllPosition[1], Quaternion.identity);
        Generator.controllPosition[2] = Handles.PositionHandle(Generator.controllPosition[2], Quaternion.identity);
        Generator.controllPosition[3] = Handles.PositionHandle(Generator.controllPosition[3], Quaternion.identity);

        // pos[0], pos[1] connetion
        Handles.DrawLine(Generator.controllPosition[0], Generator.controllPosition[1]);
        // pos[2], pos[3] connetion
        Handles.DrawLine(Generator.controllPosition[2], Generator.controllPosition[3]);

        // It gets smoother as the count goes up.
        int Count = 50;
        for (float i = 0; i < Count; i++)
        {
            float value_Before = i / Count;
            Vector2 Before = Generator.BezierTest(Generator.controllPosition[0], Generator.controllPosition[1], Generator.controllPosition[2], Generator.controllPosition[3], value_Before);

            float value_After = (i + 1) / Count;
            Vector2 After = Generator.BezierTest(Generator.controllPosition[0], Generator.controllPosition[1], Generator.controllPosition[2], Generator.controllPosition[3], value_After); ;

            Handles.DrawLine(Before, After);
        }
    }

}