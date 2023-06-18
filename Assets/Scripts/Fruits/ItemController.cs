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
        {
            Destroy(gameObject);
        }

        // 선형보간을 계산한 결과값을 프레임과 프레임 사이의 시간을 계속 더해 이동
        rate += Time.deltaTime;
        transform.position = BezierTest(controllPosition[0], controllPosition[1], controllPosition[2], controllPosition[3], rate);
        

        if (rate >= 1f)
        {
            Vector2 pushForce = Vector2.left * 250.0f;
            rb.AddForce(pushForce);
        }


        if (itemHp == 0)
        {
            if (executeOnlyOnce)
            {
                itemAnimator.SetTrigger("slice");
                rb.MovePosition(new Vector2(4f, 3f));
                Recipe.DecreaseIngredient(this.name);
                executeOnlyOnce = false;
            }
            Vector2 rightForce = Vector2.right * 250.0f;
            rb.AddForce(rightForce);
            rb.gravityScale = 15f;
        }
    }

    // https://www.youtube.com/watch?v=KTEX2L4T4zE

    // 점과 점 사잇값을 추정하기 위하여 직선 거리에 따라 선형적으로 계산하는 방법이다.
    public Vector2 BezierTest(Vector2 P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, float value)
    {
        Vector2 A = Vector2.Lerp(P_1, P_2, value);  // P_1지점과 P_2지점의 선형구간 계산값 : A
        Vector2 B = Vector2.Lerp(P_2, P_3, value);  // P_2지점과 P_3지점의 선형구간 계산값 : B
        Vector2 C = Vector2.Lerp(P_3, P_4, value);  // P_3지점과 P_4지점의 선형구간 계산값 : C

        Vector2 D = Vector2.Lerp(A, B, value);      // A지점과 B지점의 선형구간 계산값 : D
        Vector2 E = Vector2.Lerp(B, C, value);      // B지점과 C지점의 선형구간 계산값 : E

        Vector2 F = Vector2.Lerp(D, E, value);      // D지점과 E지점의 선형구간 계산값 : F
        return F;                                   // 위에서 계산한 총 결과값을 F로 반환
    }


}

// Bezier graphic area
[CanEditMultipleObjects]
[CustomEditor(typeof(ItemController))]
public class Test_Editor : Editor
{
    private void OnSceneGUI()
    {
        // 현재 오브젝트 참조
        ItemController Generator = (ItemController)target;

        // 오브젝트 제어
        // 제어 포인트 0부터 3까지의 위치를 핸들을 통해 조정합니다.
        Generator.controllPosition[0] = Handles.PositionHandle(Generator.controllPosition[0], Quaternion.identity);
        Generator.controllPosition[1] = Handles.PositionHandle(Generator.controllPosition[1], Quaternion.identity);
        Generator.controllPosition[2] = Handles.PositionHandle(Generator.controllPosition[2], Quaternion.identity);
        Generator.controllPosition[3] = Handles.PositionHandle(Generator.controllPosition[3], Quaternion.identity);

        // pos[0], pos[1] 연결
        // 제어 포인트 0과 1을 선으로 연결합니다.
        Handles.DrawLine(Generator.controllPosition[0], Generator.controllPosition[1]);
        // pos[2], pos[3] 연결
        // 제어 포인트 2와 3을 선으로 연결합니다.
        Handles.DrawLine(Generator.controllPosition[2], Generator.controllPosition[3]);

        // 카운트가 증가함에 따라 더 부드럽게 됩니다.
        int Count = 50;
        for (float i = 0; i < Count; i++)
        {
            // Bezier 곡선을 따라 이전 위치를 계산합니다.
            float value_Before = i / Count;
            Vector2 Before = Generator.BezierTest(Generator.controllPosition[0], Generator.controllPosition[1], Generator.controllPosition[2], Generator.controllPosition[3], value_Before);

            // Bezier 곡선을 따라 다음 위치를 계산합니다.
            float value_After = (i + 1) / Count;
            Vector2 After = Generator.BezierTest(Generator.controllPosition[0], Generator.controllPosition[1], Generator.controllPosition[2], Generator.controllPosition[3], value_After); ;

            // 이전 위치와 다음 위치를 선으로 연결합니다.
            Handles.DrawLine(Before, After);
        }
    }
}
