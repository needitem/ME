using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerControler : MonoBehaviour
{
    private float coolTime = 1.0f;
    [SerializeField] private float pushPower = 30.0f;
    private bool hasAttacked = false;
    private float lastAttackTime = -1f;
    private float doubleAttackTimeWindow = 0.3f;
    private Animator anim;
    public Vector2 boxSize;
    public Transform pos;
    public Animator animator;
    private Rigidbody2D rb;
    private void Start() {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Attack();
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            PunchBackColliders();
        }
    }


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
        float currentTime = Time.time;
        if (hasAttacked && (currentTime - lastAttackTime) <= doubleAttackTimeWindow)
        {
            Debug.Log("doubleAttack");
            //anim.SetTrigger("doubleAttack");
            hasAttacked = false;
        }
        else if(!hasAttacked)
        {
            Debug.Log("Attack");
            //anim.SetTrigger("attack");
            hasAttacked = true;
            lastAttackTime = currentTime;
            StartCoroutine(ResetAttack());
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
