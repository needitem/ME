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

    //승표
    bool isdoubleAttack = false; // 더블어택중인지 아닌지 보는 변수


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
            //Upscale();
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
                rigidbody.AddForce(new Vector2(-1,1) * pushPower, ForceMode2D.Impulse);
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

        if (fUpSize >= 3)
        {
            Destroy(gBackFruit);
            fUpSize = 0.2f;
            isUpScale = false;
        }
    }

    public void Attack() // 일반 공격인지, 2회 연속 공격인지 구분
    {
        float currentTime = Time.time;
        if (!isdoubleAttack) // 더블어택을 사용하지 않았다면 실행
        {
            if (hasAttacked && (currentTime - lastAttackTime) <= doubleAttackTimeWindow) // 1초 안에 스페이스바를 두번 누른상태이고, 두번째 공격을 누른시간(currentTime)에서 
            {                                                                            // 첫번째 공격을 누른시간(lastAttackTime) 사이의 시간차이가 0.3초 보다 작다면 더블어택 실행
                                                                                         // (쉽게 말해 스페이스 따닥 누른시간의 간격이 0.3보다 작으면 실행)

                isdoubleAttack = true; // 더블어택을 사용했다는 뜻                                 
                
                // 더블 어택 실행      
                Debug.Log("doubleAttack");            
                //anim.SetTrigger("doubleAttack");           
                Invoke("Delay", 1f); // 1초후 실행


            }
            else if (!hasAttacked)
            {
                // 어택 실행
                Debug.Log("Attack");            
                //anim.SetTrigger("attack");
                hasAttacked = true;
                lastAttackTime = currentTime; // 첫번째 공격시간을 lastAttackTime에 저장
                Invoke("Delay", 1f); // 1초후 실행                     
            }
        }
        else // 더블어택을 사용했다면 실행
        {
            Invoke("TransIsdoubleAttack", 1f); // 1초후 실행
        }
    }

    void Delay() // hasAttacked를 false로 변경
    {
        hasAttacked = false;
    }

    void TransIsdoubleAttack() // isdoubleAttack을 false로 변경
    {
        isdoubleAttack = false;
    }

    IEnumerator ResetAttack() // 코루틴 함수
    {
        yield return new WaitForSeconds(coolTime); // 1초 후 hasAttacked 를 false로 바꾸겠다.

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
