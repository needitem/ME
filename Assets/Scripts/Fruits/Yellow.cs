using UnityEngine;

public class Yellow : MonoBehaviour
{
    [SerializeField] private float pushPower;
    //private Rigidbody2D rb;

    [Range(0f, 1f)] public float m_rate = 0f; // 0 ~ 1 범위에서만 조작되게 제한하기 위한 설정
    public float moveSpeed = 1f;

    // 시작지점 / 종료지점 오브젝트를 받아서 Transform 를 얻어오기 위한 변수
    public Transform m_p_Start;
    public Transform m_p_End;
    // 중간지점 오브젝트를 받아서 Transform 을 얻기 위한 배열
    public Transform[] m_pos_Num = new Transform[2];

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Move the object to the right
/*        Vector2 movement = new Vector2(3, 2);
        rb.AddForce(movement * pushPower, ForceMode2D.Impulse);*/

        m_rate += Time.deltaTime;
        transform.position = GetComponent<BezierCurve_Controller>().BezierCurve();

        if (m_rate >= 1f)
        {
            m_rate = 0f;
        }
    }
}