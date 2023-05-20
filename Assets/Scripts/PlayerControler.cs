using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class PlayerControler : MonoBehaviour
{
    private float coolTime = 1.0f;
    [SerializeField] private float pushPower = 30.0f;
    private bool hasAttacked = false;
    private float lastAttackTime = -1f;
    private float doubleAttackTimeWindow = 0.3f;
    private Animator anim;
    public Vector2 boxSize;
    public Transform pos;
    public Animator animator;
    private Rigidbody2D rb;

<<<<<<< HEAD
    //ï¿½ï¿½ï¿½ï¿½
    float fUpSize; //ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Å³ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½
=======
    //½ÂÇ¥
    bool isdoubleAttack = false; // ´õºí¾îÅÃÁßÀÎÁö ¾Æ´ÑÁö º¸´Â º¯¼ö


    //±âÁØ
    float fUpSize; //Áõ°¡½ÃÅ³ »çÀÌÁî
>>>>>>> cb2f377d361e31691303bd9a3e94f89484773f5e
    bool isUpScale = false;
    GameObject gBackFruit;


    private void Start() {
        animator = GetComponent<Animator>();
        fUpSize = 0.2f;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Attack();
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            PunchBackColliders();
            //Upscale();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
        
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
                rigidbody.AddForce(new Vector2(-1,1) * pushPower, ForceMode2D.Impulse);
                this.gBackFruit = collider.gameObject;
                isUpScale = true;
            }
        }
    }

    void Upscale() {

        if (isUpScale == true)
        {
            //Æ¨ï¿½Ü³ï¿½ï¿½ï¿½ 2dï¿½ï¿½ï¿½ï¿½ zï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ Æ¨ï¿½Ü³ï¿½ï¿½â¿¡ ï¿½ï¿½ï¿½Ù¹ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½Ï¿ï¿½ ï¿½Ã°ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½Ã¼ï¿½ï¿½ï¿½ï¿½ ï¿½Ø´ï¿½.
            gBackFruit.transform.localScale = new Vector3(fUpSize, fUpSize, 0);
            fUpSize += 0.1f; //ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½
        }

        if (fUpSize >= 3)
        {
            Destroy(gBackFruit);
            fUpSize = 0.2f;
            isUpScale = false;
        }
    }

    public void Attack() // ÀÏ¹Ý °ø°ÝÀÎÁö, 2È¸ ¿¬¼Ó °ø°ÝÀÎÁö ±¸ºÐ
    {
        float currentTime = Time.time;
        if (!isdoubleAttack) // ´õºí¾îÅÃÀ» »ç¿ëÇÏÁö ¾Ê¾Ò´Ù¸é ½ÇÇà
        {
            if (hasAttacked && (currentTime - lastAttackTime) <= doubleAttackTimeWindow) // 1ÃÊ ¾È¿¡ ½ºÆäÀÌ½º¹Ù¸¦ µÎ¹ø ´©¸¥»óÅÂÀÌ°í, µÎ¹øÂ° °ø°ÝÀ» ´©¸¥½Ã°£(currentTime)¿¡¼­ 
            {                                                                            // Ã¹¹øÂ° °ø°ÝÀ» ´©¸¥½Ã°£(lastAttackTime) »çÀÌÀÇ ½Ã°£Â÷ÀÌ°¡ 0.3ÃÊ º¸´Ù ÀÛ´Ù¸é ´õºí¾îÅÃ ½ÇÇà
                                                                                         // (½±°Ô ¸»ÇØ ½ºÆäÀÌ½º µû´Ú ´©¸¥½Ã°£ÀÇ °£°ÝÀÌ 0.3º¸´Ù ÀÛÀ¸¸é ½ÇÇà)

                isdoubleAttack = true; // ´õºí¾îÅÃÀ» »ç¿ëÇß´Ù´Â ¶æ                                 
                
                // ´õºí ¾îÅÃ ½ÇÇà      
                Debug.Log("doubleAttack");            
                //anim.SetTrigger("doubleAttack");           
                Invoke("Delay", 1f); // 1ÃÊÈÄ ½ÇÇà


            }
            else if (!hasAttacked)
            {
                // ¾îÅÃ ½ÇÇà
                Debug.Log("Attack");            
                //anim.SetTrigger("attack");
                hasAttacked = true;
                lastAttackTime = currentTime; // Ã¹¹øÂ° °ø°Ý½Ã°£À» lastAttackTime¿¡ ÀúÀå
                Invoke("Delay", 1f); // 1ÃÊÈÄ ½ÇÇà                     
            }
        }
        else // ´õºí¾îÅÃÀ» »ç¿ëÇß´Ù¸é ½ÇÇà
        {
            Invoke("TransIsdoubleAttack", 1f); // 1ÃÊÈÄ ½ÇÇà
        }
    }

    void Delay() // hasAttacked¸¦ false·Î º¯°æ
    {
        hasAttacked = false;
    }

    void TransIsdoubleAttack() // isdoubleAttackÀ» false·Î º¯°æ
    {
        isdoubleAttack = false;
    }

    //IEnumerator ResetAttack() // ÄÚ·çÆ¾ ÇÔ¼ö
    //{
    //    yield return new WaitForSeconds(coolTime); // 1ÃÊ ÈÄ hasAttacked ¸¦ false·Î ¹Ù²Ù°Ú´Ù.

    //    hasAttacked = false;
    //}

    //onHit
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Target")
        {
            Destroy(collider.gameObject);
            GameDirector.hp--;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
