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

    Animator playerAnimator;
    GameObject recipeCollision;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        recipeCollision = GameObject.Find("RecipeCollision");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPunched)
        {
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
            playerAnimator.SetTrigger("attack");
            isDelay = true;
            lastAttackTime = currentTime;
            StartCoroutine(CountAttackDelay(0.4f));
        }
        else if ((currentTime - lastAttackTime) <= doubleAttackTimeWindow)
        {
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