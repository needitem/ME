using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCircle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float pushPower = 5.0f;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.right * pushPower);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameDirector.hp--;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "AttackRange")
        {
            Destroy(gameObject);
        }
    }
}
