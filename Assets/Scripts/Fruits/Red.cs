using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int hp = 2;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
