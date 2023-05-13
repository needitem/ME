using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerControler : MonoBehaviour
{

    [SerializeField] private float curTime;
    public float coolTime = 0.2f;
    private bool hasAttacked = false;
    private Animator anim;
    public Vector2 boxSize;
    public Transform pos;
    public Animator animator;
    void Update()
    {
        if (Input.GetButtonDown("Jump") && curTime <= 0)
        {
            Attack();
            curTime = coolTime;
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            PunchBackColliders();
        }
        curTime -= Time.deltaTime;
    }
    private void DestroyColliders()
    {
        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
        foreach (Collider2D collider in colliders)
        {
            Destroy(collider.gameObject);            
        }
    }

    private Rigidbody2D rb;
    [SerializeField] private float pushPower = 30.0f;
    private void PunchBackColliders()
    {
        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rigidbody = collider.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                rigidbody.AddForce(new Vector2(-1, 1) * pushPower, ForceMode2D.Impulse);
            }
        }
    }

    public void Attack()
    {
        if (!hasAttacked)
        {
            //anim.SetTrigger("attack");
            hasAttacked = true;
            StartCoroutine(ResetAttack());
        }
        else
        {
            //anim.SetTrigger("doubleAttack");
            hasAttacked = false;
        }
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(coolTime);
        hasAttacked = false;
    }

    //onHit
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Target")
        {
            Destroy(collider.gameObject);
            GameDirector.hp--;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

}
