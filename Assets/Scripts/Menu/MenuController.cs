using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject Panel_menu = null;                // ¸Ş´º ÆĞ³ÎÀ» ³ªÅ¸³»´Â °ÔÀÓ ¿ÀºêÁ§Æ®
    public GameObject Toggle1 = null;                   // SFX Åä±ÛÀ» ³ªÅ¸³»´Â °ÔÀÓ ¿ÀºêÁ§Æ®
    public GameObject Toggle2 = null;                   // BGM Åä±ÛÀ» ³ªÅ¸³»´Â °ÔÀÓ ¿ÀºêÁ§Æ®
    public Image[] OnImage;                             // È°¼ºÈ­ ÀÌ¹ÌÁö ¹è¿­
    public Image[] OffImage;                            // ºñÈ°¼ºÈ­ ÀÌ¹ÌÁö ¹è¿­

    private bool[] isMuted = new bool[2]; // SFX¿Í BGMÀÇ À½¼Ò°Å ¿©ºÎ¸¦ ÀúÀåÇÏ´Â ¹è¿­

    public void Click_Menu()    // ¸Ş´º ¹öÆ°À» Å¬¸¯ÇßÀ» °æ¿ì
    {
        Time.timeScale = 0;                             // °ÔÀÓ ½Ã°£À» ÀÏ½ÃÀûÀ¸·Î ¸ØÃä´Ï´Ù.
        Panel_menu.SetActive(true);                     // ¸Ş´º ÆĞ³ÎÀ» È°¼ºÈ­ÇÕ´Ï´Ù.
    }

    public void Click_Continue() // ¸Ş´ºÆĞ³ÎÀÇ CONTINUE ¹öÆ° Å¬¸¯ÇßÀ» °æ¿ì
    {
        Time.timeScale = 1;                             // °ÔÀÓ ½Ã°£À» ´Ù½Ã ½ÃÀÛÇÕ´Ï´Ù.
        Panel_menu.SetActive(false);                    // ¸Ş´º ÆĞ³ÎÀ» ºñÈ°¼ºÈ­ÇÕ´Ï´Ù.
    }

    public void Click_Exit() // ¸Ş´ºÆĞ³ÎÀÇ QUIT ¹öÆ° Å¬¸¯ÇßÀ» °æ¿ì
    {
        ChangeScene3();
    }

    public void ChangeScene3()
=======
    public GameObject Panel_menu = null;                // ë©”ë‰´ íŒ¨ë„ì„ ë‚˜íƒ€ë‚´ëŠ” ê²Œì„ ì˜¤ë¸Œì íŠ¸
    public GameObject Toggle1 = null;                   // SFX í† ê¸€ì„ ë‚˜íƒ€ë‚´ëŠ” ê²Œì„ ì˜¤ë¸Œì íŠ¸
    public GameObject Toggle2 = null;                   // BGM í† ê¸€ì„ ë‚˜íƒ€ë‚´ëŠ” ê²Œì„ ì˜¤ë¸Œì íŠ¸
    public Image[] OnImage;                             // í™œì„±í™” ì´ë¯¸ì§€ ë°°ì—´
    public Image[] OffImage;                            // ë¹„í™œì„±í™” ì´ë¯¸ì§€ ë°°ì—´

    private bool isMuted1 = false;                      // SFX í† ê¸€ì˜ ìŒì†Œê±° ì—¬ë¶€
    private bool isMuted2 = false;                      // BGM í† ê¸€ì˜ ìŒì†Œê±° ì—¬ë¶€

    public void Click_Menu()    // ë©”ë‰´ ë²„íŠ¼ì„ í´ë¦­í–ˆì„ ê²½ìš°
    {
        Time.timeScale = 0;                             // ê²Œì„ ì‹œê°„ì„ ì¼ì‹œì ìœ¼ë¡œ ë©ˆì¶¥ë‹ˆë‹¤.
        Panel_menu.SetActive(true);                     // ë©”ë‰´ íŒ¨ë„ì„ í™œì„±í™”í•©ë‹ˆë‹¤.
    }

    public void Click_Continue() // ë©”ë‰´íŒ¨ë„ì˜ CONTINUE ë²„íŠ¼ í´ë¦­í–ˆì„ ê²½ìš°
    {
        Time.timeScale = 1;                             // ê²Œì„ ì‹œê°„ì„ ë‹¤ì‹œ ì‹œì‘í•©ë‹ˆë‹¤.
        Panel_menu.SetActive(false);                    // ë©”ë‰´ íŒ¨ë„ì„ ë¹„í™œì„±í™”í•©ë‹ˆë‹¤.
    }

    public void Click_Exit() // ë©”ë‰´íŒ¨ë„ì˜ QUIT ë²„íŠ¼ í´ë¦­í–ˆì„ ê²½ìš°
    {
        Scenechange();                                  // Scenechange í•¨ìˆ˜ë¥¼ í˜¸ì¶œí•˜ì—¬ íƒ€ì´í‹€ ì”¬ìœ¼ë¡œ ì „í™˜í•©ë‹ˆë‹¤.
    }

    private void Scenechange() // ì”¬ ì „í™˜ í•¨ìˆ˜
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    {
        SceneManager.LoadScene("TitleScene");           // "TitleScene"ì„ ë¡œë“œí•˜ì—¬ ì”¬ì„ ì „í™˜í•©ë‹ˆë‹¤.
    }

    void Start()
    {
<<<<<<< HEAD
        Panel_menu.SetActive(false);
        isMuted[0] = false; // SFX ÃÊ±â À½¼Ò°Å »óÅÂ ¼³Á¤
        isMuted[1] = false; // BGM ÃÊ±â À½¼Ò°Å »óÅÂ ¼³Á¤
        UpdateMuteImages();
    }

    public void ToggleMute(int index) // SFX¿Í BGM Åä±ÛÀ» ±¸ºĞÇÏ´Â ÀÎµ¦½º¸¦ ¹Ş½À´Ï´Ù.
    {
        isMuted[index] = !isMuted[index]; // ÇØ´ç Åä±ÛÀÇ À½¼Ò°Å »óÅÂ¸¦ ¹İÀü½ÃÅµ´Ï´Ù.
        UpdateMuteImages();
=======
        Panel_menu.SetActive(false);                    // ë©”ë‰´ íŒ¨ë„ì„ ì²˜ìŒì—ëŠ” ë¹„í™œì„±í™”í•©ë‹ˆë‹¤.
        UpdateMuteImages();                             // ìŒì†Œê±° ì´ë¯¸ì§€ë¥¼ ì—…ë°ì´íŠ¸í•©ë‹ˆë‹¤.
    }

    public void ToggleMute1() // SFXí† ê¸€ì˜ ìŒì†Œê±° í´ë¦­í–ˆì„ê²½ìš°
    {
        isMuted1 = !isMuted1;                           // SFX í† ê¸€ì˜ ìŒì†Œê±° ì´ë¯¸ì§€ë¥¼ ë°˜ì „ì‹œí‚µë‹ˆë‹¤.
        UpdateMuteImages();                             // ìŒì†Œê±° ì´ë¯¸ì§€ë¥¼ ì—…ë°ì´íŠ¸í•©ë‹ˆë‹¤.
    }

    public void ToggleMute2() // BGMí† ê¸€ì˜ ìŒì†Œê±° í´ë¦­í–ˆì„ê²½ìš°
    {
        isMuted2 = !isMuted2;                           // BGM í† ê¸€ì˜ ìŒì†Œê±° ì´ë¯¸ì§€ë¥¼ ë°˜ì „ì‹œí‚µë‹ˆë‹¤.
        UpdateMuteImages();                             // ìŒì†Œê±° ì´ë¯¸ì§€ë¥¼ ì—…ë°ì´íŠ¸í•©ë‹ˆë‹¤.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    private void UpdateMuteImages() // ìŒì†Œê±° ì´ë¯¸ì§€ ë³€ê²½ í•¨ìˆ˜
    {
<<<<<<< HEAD
        // SFX¿Í BGM Åä±ÛÀÇ È°¼ºÈ­/ºñÈ°¼ºÈ­ ÀÌ¹ÌÁö¸¦ ¼³Á¤ÇÕ´Ï´Ù.
        for (int i = 0; i < 2; i++)
        {
            OnImage[i].gameObject.SetActive(!isMuted[i]);
            OffImage[i].gameObject.SetActive(isMuted[i]);
        }
=======
        OnImage[0].gameObject.SetActive(!isMuted1);     // SFX í† ê¸€ì˜ í™œì„±í™” ì´ë¯¸ì§€ë¥¼ ì„¤ì •í•©ë‹ˆë‹¤.
        OffImage[0].gameObject.SetActive(isMuted1);     // SFX í† ê¸€ì˜ ë¹„í™œì„±í™” ì´ë¯¸ì§€ë¥¼ ì„¤ì •í•©ë‹ˆë‹¤.
        OnImage[1].gameObject.SetActive(!isMuted2);     // BGM í† ê¸€ì˜ í™œì„±í™” ì´ë¯¸ì§€ë¥¼ ì„¤ì •í•©ë‹ˆë‹¤.
        OffImage[1].gameObject.SetActive(isMuted2);     // BGM í† ê¸€ì˜ ë¹„í™œì„±í™” ì´ë¯¸ì§€ë¥¼ ì„¤ì •í•©ë‹ˆë‹¤.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }
}