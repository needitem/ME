using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
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
