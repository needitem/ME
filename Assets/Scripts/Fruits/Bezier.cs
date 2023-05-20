using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bezier : MonoBehaviour
{
    // 선형보간이 0~1까지 표현됨
    [Range (0f,1f)] public float rate;

    // 곡선을 그리기 위해 저장해야할 위치
    public Vector2[] controllPosition;
    Vector2 pushForce = Vector2.left * 250.0f;
   
    private Rigidbody2D rb;
 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    { 
        // 오브젝트가 선형구간을 지나가기위한 프레임 간 시간 저장
        rate += Time.deltaTime;

        // 오브젝트 이동
        transform.position = BezierTest(controllPosition[0], controllPosition[1], controllPosition[2], controllPosition[3], rate);
        // 베지어 곡선은 종료지점에 도달전까지는 다른 충돌 및 이벤트 발생 불가하므로
        // 종료지점에 도착 후 충돌 및 이벤트 가능하게 하는 구간

        if (rate >= 1f)
        {
            // 종료 지점 이후 힘을 주어 오브젝트를 이동
            // (좀 가라긴해? 이거 종료지점에 도착하기전에 이벤트 구현 가능한지 더 찾아봄)
            rb.AddForce(pushForce);
            
        }
        /*if (rate > 1.3f)
        {
            // 움직임이 끝났을 때 추가 로직 처리
            rate = 0f;
        }*/
    }

    // 베지어곡선에서 선형보간을 구해주는 구간
    // (https://www.youtube.com/watch?v=KTEX2L4T4zE) 참고
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



// 이 부분은 오브젝트 위치 수정하기 편리성을 위한 구간.
// 구현에는 전혀 지장 없음.
[CanEditMultipleObjects]
[CustomEditor(typeof(Bezier))]
public class Test_Editor : Editor
{
    private void OnSceneGUI()
    {
        Bezier Generator = (Bezier)target;

        Generator.controllPosition[0] = Handles.PositionHandle(Generator.controllPosition[0], Quaternion.identity);
        Generator.controllPosition[1] = Handles.PositionHandle(Generator.controllPosition[1], Quaternion.identity);
        Generator.controllPosition[2] = Handles.PositionHandle(Generator.controllPosition[2], Quaternion.identity);
        Generator.controllPosition[3] = Handles.PositionHandle(Generator.controllPosition[3], Quaternion.identity);

        Handles.DrawLine(Generator.controllPosition[0], Generator.controllPosition[1]);
        Handles.DrawLine(Generator.controllPosition[2], Generator.controllPosition[3]);

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