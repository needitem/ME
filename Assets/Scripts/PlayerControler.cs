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

    //기준
    float fUpSize; //증가시킬 사이즈
    bool isUpScale = false;
    GameObject gBackFruit;



    private void Start() {
        animator = GetComponent<Animator>();
        fUpSize = 0.2f;
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

       
        Upscale();
    }



    private void PunchBackColliders()
    {
        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
        foreach (Collider2D collider in colliders)
        {
            
            Rigidbody2D rigidbody = collider.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                rigidbody.AddForce(new Vector2(1,1) * pushPower, ForceMode2D.Impulse);
                this.gBackFruit = collider.gameObject;
                isUpScale = true;
            }
        }
    }

    void Upscale() {

        if (isUpScale == true)
        {
            //튕겨내면 2d지만 z축으로 튕겨내기에 원근법을 사용하여 시각적인 입체감을 준다.
            gBackFruit.transform.localScale = new Vector3(fUpSize, fUpSize, 0);

            fUpSize += 0.1f; //사이즈 증가
        }


        if (fUpSize >= 6)
        {
            Destroy(gBackFruit);
            fUpSize = 0.2f;
            isUpScale = false;
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
