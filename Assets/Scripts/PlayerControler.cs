using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    Effect effect = new Effect();
    [SerializeField] private float pushPower = 30.0f;
    private bool hasAttacked = false;
    private float lastAttackTime = -1f;
    private float doubleAttackTimeWindow = 0.2f;

    public Vector2 boxSize;
    public Transform pos;
    public Animator animator;

    bool isDoubleAttack = false;
    bool isPunched = false;

    Animator playerAnimator;
    GameObject recipeCollision;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerAnimator = GetComponent<Animator>();
        recipeCollision = GameObject.Find("RecipeCollision");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPunched)
        {
            recipeCollision.GetComponent<Recipe>().OnRecipeCollision();
            Debug.Log("attack");
            Attack();
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && !hasAttacked)
        {
            var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
            foreach (Collider2D collider in colliders)
            {
                GameObject target = collider.GetComponent<GameObject>();
                if (target != null)
                {
                    effect.PunchBack(target);
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
        if (isDoubleAttack)
        {
            isDoubleAttack = false;
            return;
        }

        float currentTime = Time.time;

        if (hasAttacked && (currentTime - lastAttackTime) <= doubleAttackTimeWindow)
        {
            playerAnimator.SetTrigger("double_attack");
            isDoubleAttack = true;
        }
        else if (!hasAttacked)
        {
            playerAnimator.SetTrigger("attack");
            lastAttackTime = currentTime;
        }

        Invoke("ResetAttackDelay", 0.4f);
    }

    void ResetAttackDelay()
    {
        hasAttacked = false;
        lastAttackTime = -1f;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Target")
        {
            Destroy(collider.gameObject);
            GameDirector.hp--;
            playerAnimator.SetTrigger("damaged");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}