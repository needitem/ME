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
    bool isPunched = false;
    public bool isDelay = false; //attack delay
    Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
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
            gameObject.GetComponent<AudioSource>().mute = true; // hp가 0이 되는 순간 PlayController스크립트에 있는 모든 오디오는 mute처리
            playerAnimator.SetTrigger("game_over");
            //Change to Gameover Scene
        }

    }

    public void PunchBack()
    {
        isPunched = true;
        playerAnimator.SetTrigger("punch");

        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
        if (colliders.Count == 0)
        {
            AudioDirector.PlaySound("Sound/effect_sound/fryingpanMess"); // 후라이팬을 헛손질 했을 때 나는 소리
        }
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Target")
            {
                KatanaEffect.Punch();
                Effect.Apply(collider.gameObject);
                AudioDirector.PlaySound("Sound/effect_sound/fryingpan"); // 후라이팬과 충돌이 일어났을 때 나느 소리
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
            if (colliders.Count == 0)
            {
                AudioDirector.PlaySound("Sound/effect_sound/swing1");  // 과도칼 한번 스윙하였을때 충돌이 없을 때 나는 소리
            }
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target")
                {
                    KatanaEffect.Attack();
                    collider.gameObject.GetComponent<ItemController>().itemHp--;
                    AudioDirector.PlaySound("Sound/effect_sound/slice1"); // 과도칼 한번 스윙하였을때 충돌이 있을 때 나는 소리
                    Recipe.DecreaseIngredient(collider.name);
                }
            }

            isDelay = true;
            lastAttackTime = currentTime;
            StartCoroutine(CountAttackDelay(0.4f));
        }
        else if ((currentTime - lastAttackTime) <= doubleAttackTimeWindow)
        {
            playerAnimator.SetTrigger("double_attack");
            if (colliders.Count == 0)
            {
                AudioDirector.PlaySound("Sound/effect_sound/swing2");       // 과도칼 두번 스윙하였을때 충돌이 없을 때 나는 소리
            }
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target")
                {
                    if(collider.name == "chicken")
                    {
                        AudioDirector.PlaySound("Sound/effect_sound/slice2");       // 닭을 두번 스윙하여 충돌이 있을 때 나는 소리
                        AudioDirector.PlaySound("Sound/effect_sound/chicken");
                    }
                    else
                    {
                        AudioDirector.PlaySound("Sound/effect_sound/slice2");       // 과도칼 두번 스윙하였을때 충돌이 있을 때 나는 소리
                    }
                    
                    KatanaEffect.DoubleAttack();
                    collider.gameObject.GetComponent<ItemController>().itemHp--;
                    Recipe.DecreaseIngredient(collider.name);
                }
            }
            isDelay = true;
            StartCoroutine(CountAttackDelay(0.2f));
        }
        StartCoroutine(CountAttackDelay(0.4f));
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
            AudioDirector.PlaySound("Sound/effect_sound/hit");      // 썰지 못하고 플레이어와의 충돌이 일어났을 때 나는 소리
            playerAnimator.SetTrigger("damaged");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }



}