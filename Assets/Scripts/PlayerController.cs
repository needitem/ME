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
            gameObject.GetComponent<AudioSource>().mute = true; // hp�� 0�� �Ǵ� ���� PlayController��ũ��Ʈ�� �ִ� ��� ������� muteó��
            playerAnimator.SetTrigger("game_over");
            //Change to Gameover Scene
        }

    }

    // PunchBack �Լ��� ƨ�ܳ��� �Լ�
    public void PunchBack()
    {
        isPunched = true;
        playerAnimator.SetTrigger("punch");

        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
        if (colliders.Count == 0)
        {
            AudioDirector.PlaySound("Sound/effect_sound/fryingpanMess"); // �Ķ������� ����� ���� �� ���� �Ҹ�
        }
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Target")
            {
                KatanaEffect.Punch();
                Effect.Apply(collider.gameObject);
                AudioDirector.PlaySound("Sound/effect_sound/fryingpan"); // �Ķ����Ұ� �浹�� �Ͼ�� �� ���� �Ҹ�
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
                AudioDirector.PlaySound("Sound/effect_sound/swing1");  // ����Į �ѹ� �����Ͽ����� �浹�� ���� �� ���� �Ҹ�
            }
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target")
                {
                    KatanaEffect.Attack();
                    collider.gameObject.GetComponent<ItemController>().itemHp--;
                    AudioDirector.PlaySound("Sound/effect_sound/slice1"); // ����Į �ѹ� �����Ͽ����� �浹�� ���� �� ���� �Ҹ�
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
                AudioDirector.PlaySound("Sound/effect_sound/swing2");       // ����Į �ι� �����Ͽ����� �浹�� ���� �� ���� �Ҹ�
            }
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target")
                {
                    if(collider.name == "chicken")
                    {
                        AudioDirector.PlaySound("Sound/effect_sound/slice2");       // ���� �ι� �����Ͽ� �浹�� ���� �� ���� �Ҹ�
                        AudioDirector.PlaySound("Sound/effect_sound/chicken");
                    }
                    else
                    {
                        AudioDirector.PlaySound("Sound/effect_sound/slice2");       // ����Į �ι� �����Ͽ����� �浹�� ���� �� ���� �Ҹ�
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

    // ������ ���� �ڷ�ƾ
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
            AudioDirector.PlaySound("Sound/effect_sound/hit");      // ���� ���ϰ� �÷��̾���� �浹�� �Ͼ�� �� ���� �Ҹ�
            playerAnimator.SetTrigger("damaged");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }



}