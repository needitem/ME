using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    private bool hasAttacked = false;
    private float lastAttackTime = -1f;
    private float doubleAttackTimeWindow = 0.2f;
    bool isDoubleAttack = false;

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
            gameObject.GetComponent<AudioSource>().mute = true; //if hp is 0, mute the sound
            playerAnimator.SetTrigger("game_over");
        }

    }
    public void PunchBack() //effect of punching back ingredients
    {
        isPunched = true;
        playerAnimator.SetTrigger("punch");

        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList(); //get colliders in the box, and put them in the list
        if (colliders.Count == 0) //if there is no collider in the box, play the sound of punching air
        {
            AudioDirector.PlaySound("Sound/effect_sound/fryingpanMess"); 
        }
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Target") //if there is collider in the box, play the sound of punching ingredient
            {
                KatanaEffect.Punch();
                Effect.Apply(collider.gameObject); //apply the effect of punching back
                AudioDirector.PlaySound("Sound/effect_sound/fryingpan"); 
            }
        }
        StartCoroutine(CountAttackDelay(0.4f)); //delay of punching back
    }

    public void Attack() //
    {
   
       
        hasAttacked = true;
        float currentTime = Time.time;
        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
        if (!isDelay) //if attack delay is false, attack. attack delay is true when player attacks
        {

            playerAnimator.SetTrigger("attack");
            if (colliders.Count == 0) //if there is no collider in the box, play the sound of swinging air
            {
                AudioDirector.PlaySound("Sound/effect_sound/swing1");  
            }
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target") //if there is collider in the box, play the sound of slicing ingredient
                {
                    KatanaEffect.Attack();
                    collider.gameObject.GetComponent<ItemController>().itemHp--;
                    AudioDirector.PlaySound("Sound/effect_sound/slice1");
                    Recipe.DecreaseIngredient(collider.name); //decrease the amount of ingredient
                }
            }

            isDelay = true;
            lastAttackTime = currentTime; //reset the last attack time
            StartCoroutine(CountAttackDelay(0.4f));

        }
        else if ((currentTime - lastAttackTime) <= doubleAttackTimeWindow) //if player attacks again within 0.2 seconds
        {
            isDoubleAttack = true;
            playerAnimator.SetTrigger("double_attack");
            if (colliders.Count == 0) //if there is no collider in the box, play the sound of swinging air
            {
                AudioDirector.PlaySound("Sound/effect_sound/swing2");       
            }
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target") //if there is collider in the box, play the sound of slicing ingredient
                {
                    if(collider.name == "chicken") //if the ingredient is chicken, play the sound of slicing chicken
                    {
                        AudioDirector.PlaySound("Sound/effect_sound/chicken");
                    }
                    AudioDirector.PlaySound("Sound/effect_sound/slice2");
                    KatanaEffect.DoubleAttack();
                    collider.gameObject.GetComponent<ItemController>().itemHp--;
                    Recipe.DecreaseIngredient(collider.name);
                }
            }
            isDelay = true;
 

        }


    }

    public void InitDelay()
    {
        isDelay = false;
        isPunched = false;
        hasAttacked = false;
    }


    IEnumerator CountAttackDelay(float delayTime) 
    {
        yield return new WaitForSeconds(delayTime);

        if (!isDoubleAttack)
        {
            InitDelay();
        }
        else if (isDoubleAttack)
        {
            Invoke("InitDelay", 0.2f);
            isDoubleAttack = false;
        }

    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Target") //if player collides with ingredient, decrease hp
        {
            Destroy(collider.gameObject);
            GameDirector.hp--;
            AudioDirector.PlaySound("Sound/effect_sound/hit");     
            playerAnimator.SetTrigger("damaged");
        }
    }
}