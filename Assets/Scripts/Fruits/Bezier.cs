

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bezier : MonoBehaviour
{
    // ���������� 0~1���� ǥ����
    [Range (0f,1f)] public float rate;
    //testtesttest
    // ��� �׸��� ���� �����ؾ��� ��ġ
    public Vector2[] controllPosition;
   
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    { 
        // ������Ʈ�� ���������� ������������ ������ �� �ð� ����
        rate += Time.deltaTime;
        // ������Ʈ �̵�
        transform.position = BezierTest(controllPosition[0], controllPosition[1], controllPosition[2], controllPosition[3], rate);
        // ������ ��� ���������� ������������ �ٸ� �浹 �� �̺�Ʈ �߻� �Ұ��ϹǷ�
        // ���������� ���� �� �浹 �� �̺�Ʈ �����ϰ� �ϴ� ����
        if (rate >= 1f)
        {
            // ���� ���� ���� ���� �־� ������Ʈ�� �̵�
            // (�� �������? �̰� ���������� �����ϱ����� �̺�Ʈ ���� �������� �� ã�ƺ�)
            Vector2 pushForce = Vector2.left * 250.0f;
            rb.AddForce(pushForce);
        }
        /*if (rate > 1.3f)
        {
            // �������� ������ �� �߰� ���� ó��
            rate = 0f;
        }*/
    }

    // ���������� ���������� �����ִ� ����
    // (https://www.youtube.com/watch?v=KTEX2L4T4zE) ����
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



// �� �κ��� ������Ʈ ��ġ �����ϱ� �������� ���� ����.
// �������� ���� ���� ����.
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