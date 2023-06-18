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