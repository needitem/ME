using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerControler : MonoBehaviour
{
<<<<<<< HEAD
  //  private float coolTime = 1.0f;
=======
    //private float coolTime = 1.0f;
>>>>>>> c19c9918a2ba0105fac707fbca1db0f6026f07e5
    [SerializeField] private float pushPower = 30.0f;
    private bool hasAttacked = false;
    private float lastAttackTime = -1f;
    private float doubleAttackTimeWindow = 0.2f;
<<<<<<< HEAD
    private Animator anim;
=======

>>>>>>> c19c9918a2ba0105fac707fbca1db0f6026f07e5
    public Vector2 boxSize;
    public Transform pos;
    public Animator animator;

<<<<<<< HEAD
    //��ǥ
    bool isdoubleAttack = false; // �������������� �ƴ��� ���� ����
=======
    

    bool isdoubleAttack = false;
>>>>>>> c19c9918a2ba0105fac707fbca1db0f6026f07e5
    bool isPunched = false; //punching?

  
    float fUpSize; 
    bool isUpScale = false;
    GameObject gBackFruit;
    Animator PlayerAnimator;
    GameObject RecipeCollision;

    private void Start()
    {
        animator = GetComponent<Animator>();
        this.PlayerAnimator = GetComponent<Animator>();
        this.RecipeCollision = GameObject.Find("RecipeCollision");
        fUpSize = 1.1f;
        
    }

    private void Update()
    {
<<<<<<< HEAD

=======
>>>>>>> c19c9918a2ba0105fac707fbca1db0f6026f07e5
        if (Input.GetKeyDown(KeyCode.Space) && !isPunched)
        {
            RecipeCollision.GetComponent<Recipe>().OnRecipeCollision();
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !hasAttacked)
        {
            PunchBack();
<<<<<<< HEAD
            
=======
>>>>>>> c19c9918a2ba0105fac707fbca1db0f6026f07e5
        }

        if (isUpScale == true) {
            Upscale();
        }

<<<<<<< HEAD

=======
>>>>>>> c19c9918a2ba0105fac707fbca1db0f6026f07e5
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
   
            gBackFruit.transform.localScale = new Vector3(fUpSize, fUpSize, 0);
<<<<<<< HEAD
            fUpSize += 0.1f; //������ ����
=======
            fUpSize += 0.1f; 
>>>>>>> c19c9918a2ba0105fac707fbca1db0f6026f07e5
        }

        if (fUpSize >= 5)
        {
            Destroy(gBackFruit);
            fUpSize = 1.1f;
            isUpScale = false;
        }
    }
    bool PunchDelay1 = true;
    public void PunchBack()
    {
       
        isPunched = true;
        PunchBackColliders();

        if (PunchDelay1 == true)
        {
            PunchDelay1 = false;
            this.PlayerAnimator.SetTrigger("punch");
            Invoke("Al", 0.4f);
            
        }
        Invoke("PunchDelay", 0.4f);

       
    }

    public void Al()
    {
        PunchDelay1 = true;
    }

    bool PunchDelay1 = true;
    public void PunchBack()
    {
        isPunched = true;
        PunchBackColliders();

        if (PunchDelay1 == true)
        {
            PunchDelay1 = false;
            this.PlayerAnimator.SetTrigger("punch");
            Invoke("Al", 0.4f);
        }
        Invoke("PunchDelay", 0.4f); 
    }

    public void Al()
    {
        PunchDelay1 = true;
    }

    public void Attack() 
    {
        float currentTime = Time.time;
        if (!isdoubleAttack) 
        {
<<<<<<< HEAD
            if (hasAttacked && (currentTime - lastAttackTime) <= doubleAttackTimeWindow) // 0.5�� �ȿ� �����̽��ٸ� �ι� ���������̰�, �ι�° ������ �����ð�(currentTime)���� 
            {                                                                            // ù��° ������ �����ð�(lastAttackTime) ������ �ð����̰� 0.3�� ���� �۴ٸ� �������� ����
                hasAttacked = true;                                                                                   // (���� ���� �����̽� ���� �����ð��� ������ 0.3���� ������ ����)
=======
            if (hasAttacked && (currentTime - lastAttackTime) <= doubleAttackTimeWindow) 
            {                                                                            
                hasAttacked = true;                                                                                 
>>>>>>> c19c9918a2ba0105fac707fbca1db0f6026f07e5
                this.PlayerAnimator.SetTrigger("double_attack");
                isdoubleAttack = true;                                

                Debug.Log("doubleAttack");
                //anim.SetTrigger("doubleAttack");           

                //hasAttacked = false;
                Invoke("AttackDelay", 0.4f);

            }
            else if (!hasAttacked)
            {
                this.PlayerAnimator.SetTrigger("attack");
                Debug.Log("Attack");
                //anim.SetTrigger("attack");
                hasAttacked = true;
<<<<<<< HEAD
                lastAttackTime = currentTime; // ù��° ���ݽð��� lastAttackTime�� ����
                Invoke("AttackDelay", 0.4f); // 0.5���� ����

                
            }
        }
        //else // ���������� ����ߴٸ� ����
=======
                lastAttackTime = currentTime;
                Invoke("AttackDelay", 0.4f); 
            }
        }

>>>>>>> c19c9918a2ba0105fac707fbca1db0f6026f07e5
        if (isdoubleAttack == true) 
        {
            isdoubleAttack = false;
        }
    }

<<<<<<< HEAD
  
    void AttackDelay() // hasAttacked�� false�� ����
=======
    void AttackDelay() 
>>>>>>> c19c9918a2ba0105fac707fbca1db0f6026f07e5
    {
        hasAttacked = false;

    }

    void PunchDelay() // 튕겨내기 중인가?
    {
        isPunched = false;

    }

    void PunchDelay() // 튕겨내기 중인가?
    {
        isPunched = false;

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