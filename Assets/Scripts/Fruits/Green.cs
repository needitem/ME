using UnityEngine;
using UnityEditor;

public class Green : MonoBehaviour {
    [SerializeField] private float pushPower = 5.0f;
    [SerializeField] private float upPower = 15.0f;
    private Rigidbody2D rb;


/*    [Range(0f, 1f)] public float rate;
    public Vector2[] controllPosition;
    Bezier B_Mathod = new Bezier();*/

    void Start()
    {
/*        //rb = GetComponent<Rigidbody2D>();
        //Launch();*/
    }

    void FixedUpdate()
    {
        /*       rate += Time.deltaTime;

                if(rate > 1.3f)
                {
                    rate = 0f;
                }
                transform.position = B_Mathod.BezierTest(controllPosition[0], controllPosition[1], controllPosition[2], controllPosition[3], rate);*/

        // add gravity to the rigidbody
        rb.AddForce(new Vector2(0, Physics2D.gravity.y * rb.mass));
        // add the push force
        Vector2 pushForce = Vector2.left * pushPower;
        rb.AddForce(pushForce);

        // add the up force
        Vector2 upForce = transform.up * upPower;
        rb.AddForce(upForce);
    }

    void Launch()
    {
        // calculate the initial velocity needed for a parabolic path
        float launchAngle = 45f; // adjust this to change the angle of the parabola
        float launchSpeed = Mathf.Sqrt((upPower * upPower) / (2 * Mathf.Sin(launchAngle * Mathf.Deg2Rad)));
        Vector2 launchVelocity = new Vector2(Vector2.left.x * launchSpeed, transform.up.y * launchSpeed);

        // apply the initial velocity to the rigidbody
        rb.velocity = launchVelocity;
    }
}

/*[CanEditMultipleObjects]
[CustomEditor(typeof(Green))]
public class Test_Editor1 : Editor
{
    private void OnSceneGUI()
    {
        Green g_Generator = (Green)target;
        Bezier b_Generator = (Bezier)target;

        g_Generator.controllPosition[0] = Handles.PositionHandle(g_Generator.controllPosition[0], Quaternion.identity);
        g_Generator.controllPosition[1] = Handles.PositionHandle(g_Generator.controllPosition[1], Quaternion.identity);
        g_Generator.controllPosition[2] = Handles.PositionHandle(g_Generator.controllPosition[2], Quaternion.identity);
        g_Generator.controllPosition[3] = Handles.PositionHandle(g_Generator.controllPosition[3], Quaternion.identity);

        Handles.DrawLine(g_Generator.controllPosition[0], g_Generator.controllPosition[1]);
        Handles.DrawLine(g_Generator.controllPosition[2], g_Generator.controllPosition[3]);

        int Count = 50;
        for (float i = 0; i < Count; i++)
        {
            float value_Before = i / Count;
            Vector2 Before = b_Generator.BezierTest(g_Generator.controllPosition[0], g_Generator.controllPosition[1], g_Generator.controllPosition[2], g_Generator.controllPosition[3], value_Before);

            float value_After = (i + 1) / Count;
            Vector2 After = b_Generator.BezierTest(g_Generator.controllPosition[0], g_Generator.controllPosition[1], g_Generator.controllPosition[2], g_Generator.controllPosition[3], value_After); ;

            Handles.DrawLine(Before, After);
        }
    }
}*/