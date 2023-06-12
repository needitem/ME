using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    private bool hasAttacked = false;
    private float lastAttackTime = -1f;
    private float doubleAttackTimeWindow = 0.2f;

    public Vector2 boxSize;
    public Transform pos;
<<<<<<< HEAD
    public bool isPunched = false;
    public bool isDelay = false; //attack delay
    Animator playerAnimator, katanaAnimator;

    
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        katanaAnimator = GetComponent<Animator>();
=======
    bool isPunched = false;
    public bool isDelay = false; //attack delay
    Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
>>>>>>> 766af1bccbed5d26b5e3ad685556ce731b5139c8
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPunched)
        {
            Attack();
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && !hasAttacked)
        {
            PunchBack();
        }

        if (GameDirector.hp <= 0)
        {
            playerAnimator.SetTrigger("game_over");
            //Change to Gameover Scene
        }

    }

    public void PunchBack()
    {
        isPunched = true;
        playerAnimator.SetTrigger("punch");

        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Target")
            {
<<<<<<< HEAD
                
                KatanaEffect.Punch();
                collider.gameObject.GetComponent<ItemController>().Punch_hp--;
                
                
=======
                Effect.Apply(collider.gameObject);
>>>>>>> 766af1bccbed5d26b5e3ad685556ce731b5139c8
            }
        }
        StartCoroutine(CountAttackDelay(0.4f));
    }

    public void Attack()
    {
        hasAttacked = true;
        float currentTime = Time.time;
        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
        if (!isDelay)
        {
            playerAnimator.SetTrigger("attack");
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target")
                {
<<<<<<< HEAD
                    KatanaEffect.attack();
=======
>>>>>>> 766af1bccbed5d26b5e3ad685556ce731b5139c8
                    collider.gameObject.GetComponent<ItemController>().itemHp--;
                    Recipe.decreaseIngredient(collider.name);

                }
            }
            isDelay = true;
            lastAttackTime = currentTime;
            StartCoroutine(CountAttackDelay(0.4f));

        }
        else if ((currentTime - lastAttackTime) <= doubleAttackTimeWindow)
        {
            playerAnimator.SetTrigger("double_attack");
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target")
                {
<<<<<<< HEAD
                    KatanaEffect.DoubleAttack();
=======
>>>>>>> 766af1bccbed5d26b5e3ad685556ce731b5139c8
                    collider.gameObject.GetComponent<ItemController>().itemHp--;
                    Recipe.decreaseIngredient(collider.name);
                }
            }
            isDelay = true;
            StartCoroutine(CountAttackDelay(0.2f));
        }
<<<<<<< HEAD
     
=======
        StartCoroutine(CountAttackDelay(0.4f));
>>>>>>> 766af1bccbed5d26b5e3ad685556ce731b5139c8


    }

    IEnumerator CountAttackDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
        isPunched = false;
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