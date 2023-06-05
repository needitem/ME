using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    Effect effect;
    private bool hasAttacked = false;
    private float lastAttackTime = -1f;
    private float doubleAttackTimeWindow = 0.2f;

    public Vector2 boxSize;
    public Transform pos;
    public Animator animator;

    bool isPunched = false;
    public bool isDelay = false; //attack delay
    public Collider2D attackCollider;
    public static int AtackCount = 0;



    Animator playerAnimator;
    GameObject recipeCollision;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerAnimator = GetComponent<Animator>();
        recipeCollision = GameObject.Find("RecipeCollision");
        
        attackCollider.enabled = false;


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPunched)
        {
            //gGenerator.GetComponent<Generator>().Destroyfruits();
            recipeCollision.GetComponent<Recipe>().OnRecipeCollision();
            Attack();
        }
        
        else if (Input.GetKeyDown(KeyCode.LeftControl) && !hasAttacked)
        {
            isPunched = true;
            playerAnimator.SetTrigger("punch");
            var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
            foreach (Collider2D collider in colliders)
            {

                if (collider.tag == "Target")
                {
                    Effect.PunchBack(collider);

                }

            }
            StartCoroutine(CountAttackDelay(0.4f));


        }

        if (Effect.leftHalf != null && Effect.leftHalf.transform.position.y <= -6.0f)
        {
            Destroy(Effect.leftHalf);
        }

        if (Effect.rightHalf != null && Effect.rightHalf.transform.position.y <= -6.0f)
        {
            Destroy(Effect.rightHalf);
        }


        if (GameDirector.hp <= 0)
        {
            playerAnimator.SetTrigger("game_over");
        }

    }



    public void Attack()
    {  
        hasAttacked = true;
        float currentTime = Time.time;
        
        if (!isDelay)
        {
            StartAttack();
            AtackCount = 1;
            playerAnimator.SetTrigger("attack");
            
            isDelay = true;
            lastAttackTime = currentTime;
            StartCoroutine(CountAttackDelay(0.4f));
            
        }
        else if ((currentTime - lastAttackTime) <= doubleAttackTimeWindow)
        {
            StartAttack();
            AtackCount = 2;
            playerAnimator.SetTrigger("double_attack");
            
            isDelay = true;
        }
        StartCoroutine(CountAttackDelay(0.2f));
    }

    IEnumerator CountAttackDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
       
        isPunched = false;    

        hasAttacked = false;
        
    }

    private void StartAttack()
    {
        StartCoroutine(EnableAttackColliderForDuration(0.1f)); // 공격 콜라이더를 0.1초 동안 활성화
    }

    private IEnumerator EnableAttackColliderForDuration(float duration)
    {
        attackCollider.enabled = true; // 공격 콜라이더를 활성화

        yield return new WaitForSeconds(duration);

        attackCollider.enabled = false; // 공격 콜라이더를 비활성화
        AtackCount = 0;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Target" && attackCollider.enabled == false)
        {
            Destroy(collider.gameObject);
            GameDirector.hp--;
            playerAnimator.SetTrigger("damaged");

        }else if (collider.tag == "Target" && attackCollider.enabled == true)
        {

            Effect.Destroyfruits();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}