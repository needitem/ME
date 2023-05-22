using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerControler : MonoBehaviour
{
  //  private float coolTime = 1.0f;
    [SerializeField] private float pushPower = 30.0f;
    private bool hasAttacked = false;
    private float lastAttackTime = -1f;
    private float doubleAttackTimeWindow = 0.3f;
    private Animator anim;
    public Vector2 boxSize;
    public Transform pos;
    public Animator animator;
    private Rigidbody2D rb;

    //��ǥ
    bool isdoubleAttack = false; // �������������� �ƴ��� ���� ����


    //����
    float fUpSize; //������ų ������
    bool isUpScale = false;
    GameObject gBackFruit;
    Animator PlayerAnimator; // �÷��̾� �ִϸ�����


    private void Start()
    {
        animator = GetComponent<Animator>();
        fUpSize = 1.1f;
        this.PlayerAnimator = GetComponent<Animator>(); // �ִϸ�����  ������Ʈ�� �����´�.
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
           
        }
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            PunchBackColliders();
            this.PlayerAnimator.SetTrigger("punch");
           
        }

        if (isUpScale == true) {
            Upscale();
        }


        //hp가 0이하라면 게임오버 애니매이션 트리거 발동 
        // 추후 함수로 만들어 사용해야 한다!!!!!
        if(GameDirector.hp <= 0) 
        {
            this.PlayerAnimator.SetTrigger("game_over");
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
                rigidbody.AddForce(new Vector2(1, 1) * pushPower, ForceMode2D.Impulse);
                this.gBackFruit = collider.gameObject;
                isUpScale = true;
            }
        }
    }

    void Upscale()
    {

        if (isUpScale == true && gBackFruit != null)
        {
            //ƨ�ܳ��� 2d���� z������ ƨ�ܳ��⿡ ���ٹ��� ����Ͽ� �ð����� ��ü���� �ش�.
            gBackFruit.transform.localScale = new Vector3(fUpSize, fUpSize, 0);
            fUpSize += 0.1f; //������ ����
        }

        if (fUpSize >= 5)
        {
            Destroy(gBackFruit);
            fUpSize = 1.1f;
            isUpScale = false;
        }
    }

    public void Attack() // �Ϲ� ��������, 2ȸ ���� �������� ����
    {
        float currentTime = Time.time;
        if (!isdoubleAttack) // ���������� ������� �ʾҴٸ� ����
        {
            if (hasAttacked && (currentTime - lastAttackTime) <= doubleAttackTimeWindow) // 0.5�� �ȿ� �����̽��ٸ� �ι� ���������̰�, �ι�° ������ �����ð�(currentTime)���� 
            {                                                                            // ù��° ������ �����ð�(lastAttackTime) ������ �ð����̰� 0.3�� ���� �۴ٸ� �������� ����
                                                                                         // (���� ���� �����̽� ���� �����ð��� ������ 0.3���� ������ ����)
                this.PlayerAnimator.SetTrigger("double_attack");
                isdoubleAttack = true; // ���������� ����ߴٴ� ��                                 

                // ���� ���� ����      
                Debug.Log("doubleAttack");
                //anim.SetTrigger("doubleAttack");           
                
                hasAttacked = false;

            }
            else if (!hasAttacked)
            {
                this.PlayerAnimator.SetTrigger("attack");
                // ���� ����
                Debug.Log("Attack");
                //anim.SetTrigger("attack");
                hasAttacked = true;
                lastAttackTime = currentTime; // ù��° ���ݽð��� lastAttackTime�� ����
                Invoke("Delay", 0.4f); // 0.5���� ����

                
            }
        }
        //else // ���������� ����ߴٸ� ����
        if (isdoubleAttack == true) 
        {
            isdoubleAttack = false;
            
        }
    }

    void Delay() // hasAttacked�� false�� ����
    {
        hasAttacked = false;
    }

    //void TransIsdoubleAttack() // isdoubleAttack�� false�� ����
    //{
    //    isdoubleAttack = false;
    //}


    //IEnumerator ResetAttack() // �ڷ�ƾ �Լ�
    //{
    //    yield return new WaitForSeconds(coolTime); // 1�� �� hasAttacked �� false�� �ٲٰڴ�.

    //    hasAttacked = false;
    //}



    //onHit
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Target")
        {
            Destroy(collider.gameObject);
            GameDirector.hp--;
            this.PlayerAnimator.SetTrigger("damaged"); // 음식에 맞는 애니메이션 실행
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}