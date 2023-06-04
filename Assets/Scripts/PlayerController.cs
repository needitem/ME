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

    bool isPunched = false;
    public bool isDelay = false; //attack delay
    public Collider2D attackCollider;
    public static int AtackCount = 0;

    Animator playerAnimator;
    GameObject recipeCollision;
    GameObject gGenerator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        recipeCollision = GameObject.Find("RecipeCollision");
        gGenerator = GameObject.Find("Generator");

    
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
            playerAnimator.SetTrigger("punch");
            var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
            foreach (Collider2D collider in colliders)
            {
                GameObject target = collider.GetComponent<GameObject>();
                if (target != null)
                {
                    effect.PunchBack(target);
                    Debug.Log("test");
                }
            }
        }


        if (GameDirector.hp <= 0)
        {
            playerAnimator.SetTrigger("game_over");
        }

    }



    public void Attack()
    {
        hasAttacked = true;

        hasAttacked = true;
        float currentTime = Time.time;
        
        if (!isDelay)
        {
            StartAttack();
            AtackCount = 1;
            Debug.Log("어택 카운트 1");
            playerAnimator.SetTrigger("attack");
            
            isDelay = true;
            lastAttackTime = currentTime;
            StartCoroutine(CountAttackDelay(0.4f));
            
        }
        else if ((currentTime - lastAttackTime) <= doubleAttackTimeWindow)
        {
            StartAttack();
            AtackCount = 2;
            Debug.Log("어택 카운트 2");
            playerAnimator.SetTrigger("double_attack");
            
            isDelay = true;
        }
        StartCoroutine(CountAttackDelay(0.2f));
    }

    IEnumerator CountAttackDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
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
            gGenerator.GetComponent<Generator>().Destroyfruits();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}