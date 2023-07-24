using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneDirector : MonoBehaviour
{
<<<<<<< HEAD
    public Image FadePanel;                 // ÆÇ³Ú ¿ÀºêÁ§Æ®
    public Text ScoreText;                  // Á¡¼ö¸¦ Ç¥½ÃÇÏ´Â ÅØ½ºÆ® UI
    public float time = 0f;    
    public float F_time = 1.5f;


    IEnumerator FadeIn()
    {
        time = 0f;
        Color alpha = FadePanel.color;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            FadePanel.color = alpha;
            yield return null;
        }
    }

    // ÆäÀÌµå¾Æ¿ô È¿°ú¿Í ÇÔ²² ´Ù¸¥ ¾ÀÀ¸·Î ÀüÈ¯ÇÏ´Â ÇÔ¼ö
    public IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        time = 0f;
        Color alpha = FadePanel.color;
        while (alpha.a < 1f)
        {   
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            FadePanel.color = alpha;
            yield return null;
        }

        // ¾À ÀüÈ¯
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeScene1()
    {
        Recipe.Score = 0;                                               // Recipe ½ºÅ©¸³Æ®ÀÇ Á¡¼ö¸¦ ÃÊ±âÈ­ÇÕ´Ï´Ù.
        StartCoroutine(FadeOutAndLoadScene("GameScene"));               // ÆäÀÌµå È¿°ú¿Í ÇÔ²² "GameScene"À¸·Î ¾ÀÀ» ÀüÈ¯ÇÕ´Ï´Ù.
=======
    public Text ScoreText;  // ì ìˆ˜ë¥¼ í‘œì‹œí•˜ëŠ” í…ìŠ¤íŠ¸ UI

    public void ChangeScene1()
    {
        Recipe.Score = 0;                       // Recipe ìŠ¤í¬ë¦½íŠ¸ì˜ ì ìˆ˜ë¥¼ ì´ˆê¸°í™”í•©ë‹ˆë‹¤.
        SceneManager.LoadScene("GameScene");    // "GameScene"ìœ¼ë¡œ ì”¬ì„ ì „í™˜í•©ë‹ˆë‹¤.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    public static void ChangeScene2()
    {
<<<<<<< HEAD
        SceneManager.LoadScene("FinishScene");          // "FinishScene"À¸·Î ¾ÀÀ» ÀüÈ¯ÇÕ´Ï´Ù.
=======
        SceneManager.LoadScene("FinishScene");  // "FinishScene"ìœ¼ë¡œ ì”¬ì„ ì „í™˜í•©ë‹ˆë‹¤.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    public void ChangeScene3()
    {
<<<<<<< HEAD
        Recipe.Score = 0;                                            // Recipe ½ºÅ©¸³Æ®ÀÇ Á¡¼ö¸¦ ÃÊ±âÈ­ÇÕ´Ï´Ù.
        StartCoroutine(FadeOutAndLoadScene("TitleScene"));           // ÆäÀÌµå È¿°ú¿Í ÇÔ²² "TitleScene"À¸·Î ¾ÀÀ» ÀüÈ¯ÇÕ´Ï´Ù.
=======
        Recipe.Score = 0;                       // Recipe ìŠ¤í¬ë¦½íŠ¸ì˜ ì ìˆ˜ë¥¼ ì´ˆê¸°í™”í•©ë‹ˆë‹¤.
        SceneManager.LoadScene("TitleScene");   // "TitleScene"ìœ¼ë¡œ ì”¬ì„ ì „í™˜í•©ë‹ˆë‹¤.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    void Start()
    {
<<<<<<< HEAD
        ScoreText.text = "SCORE: " + Recipe.Score.ToString();  // ½ÃÀÛÇÒ ¶§ Á¡¼ö ÅØ½ºÆ®¸¦ ¾÷µ¥ÀÌÆ®ÇÕ´Ï´Ù.
        StartCoroutine(FadeIn());
=======
        ScoreText.text = "SCORE: " + Recipe.Score.ToString();  // ì‹œìž‘í•  ë•Œ ì ìˆ˜ í…ìŠ¤íŠ¸ë¥¼ ì—…ë°ì´íŠ¸í•©ë‹ˆë‹¤.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    void Update()
    {
    }
}