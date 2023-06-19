using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemController : MonoBehaviour
{

    [SerializeField] public int itemHp;

    bool executeOnlyOnce = true;
    // Bezier rate
    [Range(0f, 1f)] public float rate;
    // Bezier position
    public Vector2[] controllPosition;
    // End Bezier and Force
    public Rigidbody2D rb;
    Animator itemAnimator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        itemAnimator = GetComponent<Animator>();


    }

    private void FixedUpdate()
    {
        if (gameObject.transform.position.y <= 0.7f)
            // Àç·á°¡ ¸Ê ¾Æ·¡·Î ¶³¾îÁö¸é »èÁ¦ ½ÃÅ°±â
        {
            Destroy(gameObject);
        }

<<<<<<< Updated upstream
        // ì„ í˜•ë³´ê°„ì„ ê³„ì‚°í•œ ê²°ê³¼ê°’ì„ í”„ë ˆìž„ê³¼ í”„ë ˆìž„ ì‚¬ì´ì˜ ì‹œê°„ì„ ê³„ì† ë”í•´ ì´ë™
=======
        // ? í˜•ë³´ê°„??ê³„ì‚°??ê²°ê³¼ê°’ì„ ?„ë ˆ?„ê³¼ ?„ë ˆ???¬ì´???œê°„??ê³„ì† ?”í•´ ?´ë™
>>>>>>> Stashed changes
        rate += Time.deltaTime;
        transform.position = BezierTest(controllPosition[0], controllPosition[1], controllPosition[2], controllPosition[3], rate);
        

        if (rate >= 1f)
            // Àç·á°¡ »ý¼ºµÇ°í º£Áö¾î °î¼±À» µû¶ó°¡´Ù°¡, »ý¼ºµÈÁö 1ÃÊ°¡ ³ÑÀ¸¸é ¿ÞÂÊ ¹æÇâÀ¸·Î
            // AddForce¸¦ ÁÖ±â(³¯¾Æ°¡´Â µíÇÑ È¿°ú¸¦ À§ÇÔ)
        {
            Vector2 pushForce = Vector2.left * 250.0f;
            rb.AddForce(pushForce);
        }


        if (itemHp == 0) // Àç·áÀÇ hp°¡ 0ÀÌ¶ó¸é
        {
            if (executeOnlyOnce) // Àç·á ÇÏ³ª´ç ÇÑ¹ø¾¿¸¸ ½ÇÇàµÇ´Â boolÇü º¯¼ö
            {
                itemAnimator.SetTrigger("slice"); // ½½¶óÀÌ½º ¾Ö´Ï¸ÞÀÌ¼Ç ºÎ¿©
                rb.MovePosition(new Vector2(4f, 3f)); // Àç·á¸¦ ÇØ´çÀ§Ä¡·Î ÀÌµ¿½ÃÅ°±â
                Recipe.DecreaseIngredient(this.name);
                executeOnlyOnce = false;
            }
            Vector2 rightForce = Vector2.right * 250.0f;

            // ´õÀÌ»ó ¿ÞÂÊÀ¸·Î ÀÌµ¿ÇÏÁö ¾Ê°Ô ¿À¸¥ÂÊ ¹æÇâÀ¸·Î ¶È°°ÀÌ 250¸¸Å­ ÈûÀ» ÁÖ¾î Á¦ÀÚ¸®¿¡ Á¤ÁöµÈ °Í Ã³·³ º¸ÀÌ°Ô ¸¸µé±â
            rb.AddForce(rightForce);

            rb.gravityScale = 15f; // Áß·ÂÀ» ºÎ¿©ÇØ ¾Æ·¡·Î ¶³¾îÁö°Ô ÇÏ±â
        }
    }

    // https://www.youtube.com/watch?v=KTEX2L4T4zE

<<<<<<< Updated upstream
    // ì ê³¼ ì  ì‚¬ìž‡ê°’ì„ ì¶”ì •í•˜ê¸° ìœ„í•˜ì—¬ ì§ì„  ê±°ë¦¬ì— ë”°ë¼ ì„ í˜•ì ìœ¼ë¡œ ê³„ì‚°í•˜ëŠ” ë°©ë²•ì´ë‹¤.
    public Vector2 BezierTest(Vector2 P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, float value)
    {
        Vector2 A = Vector2.Lerp(P_1, P_2, value);  // P_1ì§€ì ê³¼ P_2ì§€ì ì˜ ì„ í˜•êµ¬ê°„ ê³„ì‚°ê°’ : A
        Vector2 B = Vector2.Lerp(P_2, P_3, value);  // P_2ì§€ì ê³¼ P_3ì§€ì ì˜ ì„ í˜•êµ¬ê°„ ê³„ì‚°ê°’ : B
        Vector2 C = Vector2.Lerp(P_3, P_4, value);  // P_3ì§€ì ê³¼ P_4ì§€ì ì˜ ì„ í˜•êµ¬ê°„ ê³„ì‚°ê°’ : C

        Vector2 D = Vector2.Lerp(A, B, value);      // Aì§€ì ê³¼ Bì§€ì ì˜ ì„ í˜•êµ¬ê°„ ê³„ì‚°ê°’ : D
        Vector2 E = Vector2.Lerp(B, C, value);      // Bì§€ì ê³¼ Cì§€ì ì˜ ì„ í˜•êµ¬ê°„ ê³„ì‚°ê°’ : E

        Vector2 F = Vector2.Lerp(D, E, value);      // Dì§€ì ê³¼ Eì§€ì ì˜ ì„ í˜•êµ¬ê°„ ê³„ì‚°ê°’ : F
        return F;                                   // ìœ„ì—ì„œ ê³„ì‚°í•œ ì´ ê²°ê³¼ê°’ì„ Fë¡œ ë°˜í™˜
=======
    // ?ê³¼ ???¬ìž‡ê°’ì„ ì¶”ì •?˜ê¸° ?„í•˜??ì§ì„  ê±°ë¦¬???°ë¼ ? í˜•?ìœ¼ë¡?ê³„ì‚°?˜ëŠ” ë°©ë²•?´ë‹¤.
    public Vector2 BezierTest(Vector2 P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, float value)
    {
        Vector2 A = Vector2.Lerp(P_1, P_2, value);  // P_1ì§€?ê³¼ P_2ì§€?ì˜ ? í˜•êµ¬ê°„ ê³„ì‚°ê°?: A
        Vector2 B = Vector2.Lerp(P_2, P_3, value);  // P_2ì§€?ê³¼ P_3ì§€?ì˜ ? í˜•êµ¬ê°„ ê³„ì‚°ê°?: B
        Vector2 C = Vector2.Lerp(P_3, P_4, value);  // P_3ì§€?ê³¼ P_4ì§€?ì˜ ? í˜•êµ¬ê°„ ê³„ì‚°ê°?: C

        Vector2 D = Vector2.Lerp(A, B, value);      // Aì§€?ê³¼ Bì§€?ì˜ ? í˜•êµ¬ê°„ ê³„ì‚°ê°?: D
        Vector2 E = Vector2.Lerp(B, C, value);      // Bì§€?ê³¼ Cì§€?ì˜ ? í˜•êµ¬ê°„ ê³„ì‚°ê°?: E

        Vector2 F = Vector2.Lerp(D, E, value);      // Dì§€?ê³¼ Eì§€?ì˜ ? í˜•êµ¬ê°„ ê³„ì‚°ê°?: F
        return F;                                   // ?„ì—??ê³„ì‚°??ì´?ê²°ê³¼ê°’ì„ Fë¡?ë°˜í™˜
>>>>>>> Stashed changes
    }


}

// Bezier graphic area
[CanEditMultipleObjects]
[CustomEditor(typeof(ItemController))]
public class Test_Editor : Editor
{
    private void OnSceneGUI()
    {
<<<<<<< Updated upstream
        // í˜„ìž¬ ì˜¤ë¸Œì íŠ¸ ì°¸ì¡°
        ItemController Generator = (ItemController)target;

        // ì˜¤ë¸Œì íŠ¸ ì œì–´
        // ì œì–´ í¬ì¸íŠ¸ 0ë¶€í„° 3ê¹Œì§€ì˜ ìœ„ì¹˜ë¥¼ í•¸ë“¤ì„ í†µí•´ ì¡°ì •í•©ë‹ˆë‹¤.
=======
        // ?„ìž¬ ?¤ë¸Œ?íŠ¸ ì°¸ì¡°
        ItemController Generator = (ItemController)target;

        // ?¤ë¸Œ?íŠ¸ ?œì–´
        // ?œì–´ ?¬ì¸??0ë¶€??3ê¹Œì????„ì¹˜ë¥??¸ë“¤???µí•´ ì¡°ì •?©ë‹ˆ??
>>>>>>> Stashed changes
        Generator.controllPosition[0] = Handles.PositionHandle(Generator.controllPosition[0], Quaternion.identity);
        Generator.controllPosition[1] = Handles.PositionHandle(Generator.controllPosition[1], Quaternion.identity);
        Generator.controllPosition[2] = Handles.PositionHandle(Generator.controllPosition[2], Quaternion.identity);
        Generator.controllPosition[3] = Handles.PositionHandle(Generator.controllPosition[3], Quaternion.identity);

<<<<<<< Updated upstream
        // pos[0], pos[1] ì—°ê²°
        // ì œì–´ í¬ì¸íŠ¸ 0ê³¼ 1ì„ ì„ ìœ¼ë¡œ ì—°ê²°í•©ë‹ˆë‹¤.
        Handles.DrawLine(Generator.controllPosition[0], Generator.controllPosition[1]);
        // pos[2], pos[3] ì—°ê²°
        // ì œì–´ í¬ì¸íŠ¸ 2ì™€ 3ì„ ì„ ìœ¼ë¡œ ì—°ê²°í•©ë‹ˆë‹¤.
        Handles.DrawLine(Generator.controllPosition[2], Generator.controllPosition[3]);

        // ì¹´ìš´íŠ¸ê°€ ì¦ê°€í•¨ì— ë”°ë¼ ë” ë¶€ë“œëŸ½ê²Œ ë©ë‹ˆë‹¤.
        int Count = 50;
        for (float i = 0; i < Count; i++)
        {
            // Bezier ê³¡ì„ ì„ ë”°ë¼ ì´ì „ ìœ„ì¹˜ë¥¼ ê³„ì‚°í•©ë‹ˆë‹¤.
            float value_Before = i / Count;
            Vector2 Before = Generator.BezierTest(Generator.controllPosition[0], Generator.controllPosition[1], Generator.controllPosition[2], Generator.controllPosition[3], value_Before);

            // Bezier ê³¡ì„ ì„ ë”°ë¼ ë‹¤ìŒ ìœ„ì¹˜ë¥¼ ê³„ì‚°í•©ë‹ˆë‹¤.
            float value_After = (i + 1) / Count;
            Vector2 After = Generator.BezierTest(Generator.controllPosition[0], Generator.controllPosition[1], Generator.controllPosition[2], Generator.controllPosition[3], value_After); ;

            // ì´ì „ ìœ„ì¹˜ì™€ ë‹¤ìŒ ìœ„ì¹˜ë¥¼ ì„ ìœ¼ë¡œ ì—°ê²°í•©ë‹ˆë‹¤.
=======
        // pos[0], pos[1] ?°ê²°
        // ?œì–´ ?¬ì¸??0ê³?1??? ìœ¼ë¡??°ê²°?©ë‹ˆ??
        Handles.DrawLine(Generator.controllPosition[0], Generator.controllPosition[1]);
        // pos[2], pos[3] ?°ê²°
        // ?œì–´ ?¬ì¸??2?€ 3??? ìœ¼ë¡??°ê²°?©ë‹ˆ??
        Handles.DrawLine(Generator.controllPosition[2], Generator.controllPosition[3]);

        // ì¹´ìš´?¸ê? ì¦ê??¨ì— ?°ë¼ ??ë¶€?œëŸ½ê²??©ë‹ˆ??
        int Count = 50;
        for (float i = 0; i < Count; i++)
        {
            // Bezier ê³¡ì„ ???°ë¼ ?´ì „ ?„ì¹˜ë¥?ê³„ì‚°?©ë‹ˆ??
            float value_Before = i / Count;
            Vector2 Before = Generator.BezierTest(Generator.controllPosition[0], Generator.controllPosition[1], Generator.controllPosition[2], Generator.controllPosition[3], value_Before);

            // Bezier ê³¡ì„ ???°ë¼ ?¤ìŒ ?„ì¹˜ë¥?ê³„ì‚°?©ë‹ˆ??
            float value_After = (i + 1) / Count;
            Vector2 After = Generator.BezierTest(Generator.controllPosition[0], Generator.controllPosition[1], Generator.controllPosition[2], Generator.controllPosition[3], value_After); ;

            // ?´ì „ ?„ì¹˜?€ ?¤ìŒ ?„ì¹˜ë¥?? ìœ¼ë¡??°ê²°?©ë‹ˆ??
>>>>>>> Stashed changes
            Handles.DrawLine(Before, After);
        }
    }
}
