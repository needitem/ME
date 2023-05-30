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
    private float doubleAttackTimeWindow = 0.2f;
    private Animator anim;
    public Vector2 boxSize;
    public Transform pos;
    public Animator animator;
    private Rigidbody2D rb;

    //��ǥ
    bool isPunched = false; //punching?
    public bool isDelay = false; //attack delay
    bool PunchDelay = false; // punchdelay

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
      

        if (Input.GetKeyDown(KeyCode.Space) && !isPunched)
        {
            Attack();

        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !hasAttacked)
        {
            PunchBack();
            
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
                collider.enabled = false;
                rigidbody.AddForce(new Vector2(1, 1) * pushPower, ForceMode2D.Impulse);
                this.gBackFruit = collider.gameObject;
                isUpScale = true;
            }
        }

        //Collider2D[] colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        //foreach (Collider2D collider in colliders)
        //{
        //    if (collider.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
        //    {
        //        rigidbody.AddForce(new Vector2(1, 1) * pushPower, ForceMode2D.Impulse);
        //        gBackFruit = collider.gameObject;
        //        isUpScale = true;
        //    }
        //}
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
    
    public void PunchBack()
    {
       
        isPunched = true;
        PunchBackColliders();

        if (!PunchDelay)
        {
            PunchDelay = true;
            this.PlayerAnimator.SetTrigger("punch");
            StartCoroutine(CountPunchDelay());
        }
        else
        {
            Debug.Log("튕겨내기 딜레이");

        }
        StartCoroutine(CountPunchDelay2());
       
    }

    IEnumerator CountPunchDelay()
    {
        yield return new WaitForSeconds(0.4f);
        PunchDelay = false;
    }

    IEnumerator CountPunchDelay2()
    {
        yield return new WaitForSeconds(0.2f);
        isPunched = false;
    }


    public void Attack()
    {
        hasAttacked = true;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float currentTime = Time.time;
            if (!isDelay)
            {
                this.PlayerAnimator.SetTrigger("attack");
                isDelay = true;
                Debug.Log("공격");
                lastAttackTime = currentTime;
                StartCoroutine(CountAttackDelay());
            }            
            else if((currentTime - lastAttackTime) <= doubleAttackTimeWindow)
            {
                this.PlayerAnimator.SetTrigger("double_attack");
                isDelay = true;
                Debug.Log("더블공격");
                
            }
            else
            {
                Debug.Log("딜레이");
                
            }
            StartCoroutine(CountAttackDelay2());
        }
    }

    IEnumerator CountAttackDelay()
    {
        yield return new WaitForSeconds(0.4f);
        isDelay = false;
        hasAttacked = false;
    }

    IEnumerator CountAttackDelay2()
    {
        yield return new WaitForSeconds(0.2f);
        hasAttacked = false;
    }

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