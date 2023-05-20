<<<<<<< HEAD


=======
>>>>>>> 9477dc4e5e15493ab46679fb065e0346906c8add
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bezier : MonoBehaviour
{
<<<<<<< HEAD
    // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ 0~1ï¿½ï¿½ï¿½ï¿½ Ç¥ï¿½ï¿½ï¿½ï¿½
    [Range (0f,1f)] public float rate;
    //testtesttest
    // ï¿½î¼±ï¿½ï¿½ ï¿½×¸ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½Ø¾ï¿½ï¿½ï¿½ ï¿½ï¿½Ä¡
=======
    // ¼±Çüº¸°£ÀÌ 0~1±îÁö Ç¥ÇöµÊ
    [Range (0f,1f)] public float rate;
    
    // °î¼±À» ±×¸®±â À§ÇØ ÀúÀåÇØ¾ßÇÒ À§Ä¡
>>>>>>> 9477dc4e5e15493ab46679fb065e0346906c8add
    public Vector2[] controllPosition;
   
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    { 
<<<<<<< HEAD
        // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ®ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ ï¿½Ã°ï¿½ ï¿½ï¿½ï¿½ï¿½
        rate += Time.deltaTime;
        // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ® ï¿½Ìµï¿½
        transform.position = BezierTest(controllPosition[0], controllPosition[1], controllPosition[2], controllPosition[3], rate);
        // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½î¼±ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½Ù¸ï¿½ ï¿½æµ¹ ï¿½ï¿½ ï¿½Ìºï¿½Æ® ï¿½ß»ï¿½ ï¿½Ò°ï¿½ï¿½Ï¹Ç·ï¿½
        // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ ï¿½æµ¹ ï¿½ï¿½ ï¿½Ìºï¿½Æ® ï¿½ï¿½ï¿½ï¿½ï¿½Ï°ï¿½ ï¿½Ï´ï¿½ ï¿½ï¿½ï¿½ï¿½
        if (rate >= 1f)
        {
            // ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½Ö¾ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ®ï¿½ï¿½ ï¿½Ìµï¿½
            // (ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½? ï¿½Ì°ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½Ï±ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½Ìºï¿½Æ® ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ Ã£ï¿½Æºï¿½)
=======
        // ¿ÀºêÁ§Æ®°¡ ¼±Çü±¸°£À» Áö³ª°¡±âÀ§ÇÑ ÇÁ·¹ÀÓ °£ ½Ã°£ ÀúÀå
        rate += Time.deltaTime;
        // ¿ÀºêÁ§Æ® ÀÌµ¿
        transform.position = BezierTest(controllPosition[0], controllPosition[1], controllPosition[2], controllPosition[3], rate);
        // º£Áö¾î °î¼±Àº Á¾·áÁöÁ¡¿¡ µµ´ÞÀü±îÁö´Â ´Ù¸¥ Ãæµ¹ ¹× ÀÌº¥Æ® ¹ß»ý ºÒ°¡ÇÏ¹Ç·Î
        // Á¾·áÁöÁ¡¿¡ µµÂø ÈÄ Ãæµ¹ ¹× ÀÌº¥Æ® °¡´ÉÇÏ°Ô ÇÏ´Â ±¸°£
        if (rate >= 1f)
        {
            // Á¾·á ÁöÁ¡ ÀÌÈÄ ÈûÀ» ÁÖ¾î ¿ÀºêÁ§Æ®¸¦ ÀÌµ¿
            // (Á» °¡¶ó±äÇØ? ÀÌ°Å Á¾·áÁöÁ¡¿¡ µµÂøÇÏ±âÀü¿¡ ÀÌº¥Æ® ±¸Çö °¡´ÉÇÑÁö ´õ Ã£¾Æº½)
>>>>>>> 9477dc4e5e15493ab46679fb065e0346906c8add
            Vector2 pushForce = Vector2.left * 250.0f;
            rb.AddForce(pushForce);
        }
        /*if (rate > 1.3f)
        {
<<<<<<< HEAD
            // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ ï¿½ß°ï¿½ ï¿½ï¿½ï¿½ï¿½ Ã³ï¿½ï¿½
=======
            // ¿òÁ÷ÀÓÀÌ ³¡³µÀ» ¶§ Ãß°¡ ·ÎÁ÷ Ã³¸®
>>>>>>> 9477dc4e5e15493ab46679fb065e0346906c8add
            rate = 0f;
        }*/
    }

<<<<<<< HEAD
    // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½î¼±ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½Ö´ï¿½ ï¿½ï¿½ï¿½ï¿½
    // (https://www.youtube.com/watch?v=KTEX2L4T4zE) ï¿½ï¿½ï¿½ï¿½
=======
    // º£Áö¾î°î¼±¿¡¼­ ¼±Çüº¸°£À» ±¸ÇØÁÖ´Â ±¸°£
    // (https://www.youtube.com/watch?v=KTEX2L4T4zE) Âü°í
>>>>>>> 9477dc4e5e15493ab46679fb065e0346906c8add
    public Vector2 BezierTest(Vector2 P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, float value)
    {
        Vector2 A = Vector2.Lerp(P_1, P_2, value);
        Vector2 B = Vector2.Lerp(P_2, P_3, value);
        Vector2 C = Vector2.Lerp(P_3, P_4, value);

        Vector2 D = Vector2.Lerp(A, B, value);
        Vector2 E = Vector2.Lerp(B, C, value);

        Vector2 F = Vector2.Lerp(D, E, value);
        return F; 
    }
}



<<<<<<< HEAD
// ï¿½ï¿½ ï¿½Îºï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ® ï¿½ï¿½Ä¡ ï¿½ï¿½ï¿½ï¿½ï¿½Ï±ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½.
// ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½.
=======
// ÀÌ ºÎºÐÀº ¿ÀºêÁ§Æ® À§Ä¡ ¼öÁ¤ÇÏ±â Æí¸®¼ºÀ» À§ÇÑ ±¸°£.
// ±¸Çö¿¡´Â ÀüÇô ÁöÀå ¾øÀ½.
>>>>>>> 9477dc4e5e15493ab46679fb065e0346906c8add
[CanEditMultipleObjects]
[CustomEditor(typeof(Bezier))]
public class Test_Editor : Editor
{
    private void OnSceneGUI()
    {
        Bezier Generator = (Bezier)target;

        Generator.controllPosition[0] = Handles.PositionHandle(Generator.controllPosition[0], Quaternion.identity);
        Generator.controllPosition[1] = Handles.PositionHandle(Generator.controllPosition[1], Quaternion.identity);
        Generator.controllPosition[2] = Handles.PositionHandle(Generator.controllPosition[2], Quaternion.identity);
        Generator.controllPosition[3] = Handles.PositionHandle(Generator.controllPosition[3], Quaternion.identity);

        Handles.DrawLine(Generator.controllPosition[0], Generator.controllPosition[1]);
        Handles.DrawLine(Generator.controllPosition[2], Generator.controllPosition[3]);

        int Count = 50;
        for (float i = 0; i < Count; i++)
        {
            float value_Before = i / Count;
            Vector2 Before = Generator.BezierTest(Generator.controllPosition[0], Generator.controllPosition[1], Generator.controllPosition[2], Generator.controllPosition[3], value_Before);

            float value_After = (i + 1) / Count;
            Vector2 After = Generator.BezierTest(Generator.controllPosition[0], Generator.controllPosition[1], Generator.controllPosition[2], Generator.controllPosition[3], value_After); ;

            Handles.DrawLine(Before, After);
        }
    }
}