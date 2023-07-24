using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class GameDirector : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] public int maxHp = 3;              // ÇÃ·¹ÀÌ¾îÀÇ ÃÖ´ë HP
    [SerializeField] public Image[] heartImages;        // ÇÃ·¹ÀÌ¾îÀÇ HP¸¦ ³ªÅ¸³»´Â ÇÏÆ® ÀÌ¹ÌÁö ¹è¿­
    [SerializeField] GameObject[] gIngredient_cnt;      // Àç·á °³¼ö ÅØ½ºÆ®¸¦ ³ªÅ¸³»´Â °ÔÀÓ ¿ÀºêÁ§Æ® ¹è¿­
    [SerializeField] public GameObject Gameover_Panel;  // °ÔÀÓ ¿À¹ö ÆÐ³Î ¿ÀºêÁ§Æ®

    public Recipe recipe;                   // ·¹½ÃÇÇ ½ºÅ©¸³Æ® ÂüÁ¶
    public Image recipeImage;               // ·¹½ÃÇÇ ÀÌ¹ÌÁö ÄÄÆ÷³ÍÆ®
    public Image[] ingredientImages;        // Àç·á ÀÌ¹ÌÁö ÄÄÆ÷³ÍÆ® ¹è¿­

    public Sprite[] recipeSprites;          // ·¹½ÃÇÇ ½ºÇÁ¶óÀÌÆ® ¹è¿­
    public Sprite[] ingredientSprites;      // Àç·á ½ºÇÁ¶óÀÌÆ® ¹è¿­


    static public int hp;   // ÇÃ·¹ÀÌ¾îÀÇ ÇöÀç hp(static)
=======
    [SerializeField] public int maxHp = 3;              // í”Œë ˆì´ì–´ì˜ ìµœëŒ€ HP
    [SerializeField] public Image[] heartImages;        // í”Œë ˆì´ì–´ì˜ HPë¥¼ ë‚˜íƒ€ë‚´ëŠ” í•˜íŠ¸ ì´ë¯¸ì§€ ë°°ì—´
    [SerializeField] GameObject[] gIngredient_cnt;      // ìž¬ë£Œ ê°œìˆ˜ í…ìŠ¤íŠ¸ë¥¼ ë‚˜íƒ€ë‚´ëŠ” ê²Œìž„ ì˜¤ë¸Œì íŠ¸ ë°°ì—´
    [SerializeField] public GameObject Gameover_Panel;  // ê²Œìž„ ì˜¤ë²„ íŒ¨ë„ ì˜¤ë¸Œì íŠ¸

    public Recipe recipe;                   // ë ˆì‹œí”¼ ìŠ¤í¬ë¦½íŠ¸ ì°¸ì¡°
    public Image recipeImage;               // ë ˆì‹œí”¼ ì´ë¯¸ì§€ ì»´í¬ë„ŒíŠ¸
    public Image[] ingredientImages;        // ìž¬ë£Œ ì´ë¯¸ì§€ ì»´í¬ë„ŒíŠ¸ ë°°ì—´

    public Sprite[] recipeSprites;          // ë ˆì‹œí”¼ ìŠ¤í”„ë¼ì´íŠ¸ ë°°ì—´
    public Sprite[] ingredientSprites;      // ìž¬ë£Œ ìŠ¤í”„ë¼ì´íŠ¸ ë°°ì—´


    static public int hp;   // í”Œë ˆì´ì–´ì˜ í˜„ìž¬ hp(static)
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d


    // Start is called before the first frame update


    void Start()
    {
<<<<<<< HEAD
        Application.targetFrameRate = 60;       //¸ð¹ÙÀÏ È¯°æÀÏ °æ¿ì ÇÁ·¹ÀÓÀ» 60À¸·Î °íÁ¤
        QualitySettings.vSyncCount = 0;

        hp = maxHp;                             // HP¸¦ ÃÖ´ë °ª(3)À¸·Î ¼³Á¤
        Time.timeScale = 1;                     // ½Ã°£ ½ºÄÉÀÏÀ» 1·Î ¼³Á¤ (ÀÏ¹Ý ¼Óµµ)
                                                // Time.timeScale ¸Þ¼­µå¸¦ »ç¿ëÇÏ¿© ½Ã°£½ºÄÉÀÏÀ» 1·Î ¼±¾ð(½Ã°£ Èå¸§À» Á¤»ó ¼Óµµ·Î)
                                                // Time.timeScale = 0(½Ã°£ Èå¸§À» ¸ØÃã)
        UpdateRecipeCnt();                      // UI¿¡¼­ Àç·á °³¼ö ¾÷µ¥ÀÌÆ®
        UpdateRecipeUI();                       // UI¿¡¼­ ·¹½ÃÇÇ¿Í Àç·á ÀÌ¹ÌÁö ¾÷µ¥ÀÌÆ®
=======
        Application.targetFrameRate = 60;       //ëª¨ë°”ì¼ í™˜ê²½ì¼ ê²½ìš° í”„ë ˆìž„ì„ 60ìœ¼ë¡œ ê³ ì •
        QualitySettings.vSyncCount = 0;

        hp = maxHp;                             // HPë¥¼ ìµœëŒ€ ê°’(3)ìœ¼ë¡œ ì„¤ì •
        Time.timeScale = 1;                     // ì‹œê°„ ìŠ¤ì¼€ì¼ì„ 1ë¡œ ì„¤ì • (ì¼ë°˜ ì†ë„)
                                                // Time.timeScale ë©”ì„œë“œë¥¼ ì‚¬ìš©í•˜ì—¬ ì‹œê°„ìŠ¤ì¼€ì¼ì„ 1ë¡œ ì„ ì–¸(ì‹œê°„ íë¦„ì„ ì •ìƒ ì†ë„ë¡œ)
                                                // Time.timeScale = 0(ì‹œê°„ íë¦„ì„ ë©ˆì¶¤)
        UpdateRecipeCnt();                      // UIì—ì„œ ìž¬ë£Œ ê°œìˆ˜ ì—…ë°ì´íŠ¸
        UpdateRecipeUI();                       // UIì—ì„œ ë ˆì‹œí”¼ì™€ ìž¬ë£Œ ì´ë¯¸ì§€ ì—…ë°ì´íŠ¸
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        UpdateHearthp();        // UI¿¡¼­ ÇÃ·¹ÀÌ¾îÀÇ HP¸¦ ³ªÅ¸³»´Â ÇÏÆ® ÀÌ¹ÌÁö ¾÷µ¥ÀÌÆ®
        UpdateRecipeCnt();      // UI¿¡¼­ Àç·á °³¼ö ¾÷µ¥ÀÌÆ®
        UpdateRecipeUI();       // UI¿¡¼­ ·¹½ÃÇÇ¿Í Àç·á ÀÌ¹ÌÁö ¾÷µ¥ÀÌÆ®

        if (hp <= 0)            // hp°¡ 0ÀÌ¶ó¸é
        {
            Invoke("ActivateGameover", 3f);     // 3ÃÊ ÈÄ °ÔÀÓ ¿À¹ö ÆÐ³ÎÀ» È°¼ºÈ­
            Invoke("GameOverChange", 5f);       // 5ÃÊ ÈÄ °ÔÀÓ ¿À¹ö ¾ÀÀ¸·Î ÀüÈ¯                                               
                                                // Invoke("Æ¯Á¤ÇÔ¼ö", "xf") 
        }                                       // Æ¯Á¤ ÇÔ¼ö¸¦ xÃÊ ÈÄ¿¡ ºÒ·¯¿À°Ô ÇÑ´Ù.
=======
        UpdateHearthp();        // UIì—ì„œ í”Œë ˆì´ì–´ì˜ HPë¥¼ ë‚˜íƒ€ë‚´ëŠ” í•˜íŠ¸ ì´ë¯¸ì§€ ì—…ë°ì´íŠ¸
        UpdateRecipeCnt();      // UIì—ì„œ ìž¬ë£Œ ê°œìˆ˜ ì—…ë°ì´íŠ¸
        UpdateRecipeUI();       // UIì—ì„œ ë ˆì‹œí”¼ì™€ ìž¬ë£Œ ì´ë¯¸ì§€ ì—…ë°ì´íŠ¸

        if (hp <= 0)            // hpê°€ 0ì´ë¼ë©´
        {
            Invoke("ActivateGameover", 3f);     // 3ì´ˆ í›„ ê²Œìž„ ì˜¤ë²„ íŒ¨ë„ì„ í™œì„±í™”
            Invoke("GameOverChange", 5f);       // 5ì´ˆ í›„ ê²Œìž„ ì˜¤ë²„ ì”¬ìœ¼ë¡œ ì „í™˜                                               
                                                // Invoke("íŠ¹ì •í•¨ìˆ˜", "xf") 
        }                                       // íŠ¹ì • í•¨ìˆ˜ë¥¼ xì´ˆ í›„ì— ë¶ˆëŸ¬ì˜¤ê²Œ í•œë‹¤.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    public void UpdateRecipeCnt()
    {
<<<<<<< HEAD
        for (int i = 0; i < 4; i++)     // 0ºÎÅÍ 3±îÁöÀÇ ÀÎµ¦½º¸¦ »ç¿ëÇÏ¿© ¹Ýº¹
        {   
            try{
                // ÀÜ¿© ·¹½ÃÇÇ °³¼ö¸¦ °¡Á®¿Í¼­ UI¿¡ ¾÷µ¥ÀÌÆ®
                // Recipe.ShowLeftoverRecipe().Values.ToList()[i]¸¦ »ç¿ëÇÏ¿© ÀÜ¿© ·¹½ÃÇÇ °³¼ö¸¦ °¡Á®¿Â´Ù.
                // gIngredient_cnt[i].GetComponent<Text>().text¸¦ »ç¿ëÇÏ¿©
                // gIngredient_cnt ¹è¿­¿¡¼­ ÇöÀç ÀÎµ¦½º¿¡ ÇØ´çÇÏ´Â GameObjectÀÇ Text ÄÄÆ÷³ÍÆ®¸¦ °¡Á®¿Â´Ù.
=======
        for (int i = 0; i < 4; i++)     // 0ë¶€í„° 3ê¹Œì§€ì˜ ì¸ë±ìŠ¤ë¥¼ ì‚¬ìš©í•˜ì—¬ ë°˜ë³µ
        {   
            try{
                // ìž”ì—¬ ë ˆì‹œí”¼ ê°œìˆ˜ë¥¼ ê°€ì ¸ì™€ì„œ UIì— ì—…ë°ì´íŠ¸
                // Recipe.ShowLeftoverRecipe().Values.ToList()[i]ë¥¼ ì‚¬ìš©í•˜ì—¬ ìž”ì—¬ ë ˆì‹œí”¼ ê°œìˆ˜ë¥¼ ê°€ì ¸ì˜¨ë‹¤.
                // gIngredient_cnt[i].GetComponent<Text>().textë¥¼ ì‚¬ìš©í•˜ì—¬
                // gIngredient_cnt ë°°ì—´ì—ì„œ í˜„ìž¬ ì¸ë±ìŠ¤ì— í•´ë‹¹í•˜ëŠ” GameObjectì˜ Text ì»´í¬ë„ŒíŠ¸ë¥¼ ê°€ì ¸ì˜¨ë‹¤.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
                gIngredient_cnt[i].GetComponent<Text>().text = "x" + Recipe.ShowLeftoverRecipe().Values.ToList()[i];
            }
            catch
            {
<<<<<<< HEAD
                // ¸¸¾à ¿¹¿Ü°¡ ¹ß»ýÇÑ´Ù¸é(°³¼ö°¡ ¾øÀ» °æ¿ì), ÇØ´ç ÀÎµ¦½º¿¡ ÇØ´çÇÏ´Â Text ÄÄÆ÷³ÍÆ®ÀÇ text ¼Ó¼ºÀ» ºñ¿öµÐ´Ù.
=======
                // ë§Œì•½ ì˜ˆì™¸ê°€ ë°œìƒí•œë‹¤ë©´(ê°œìˆ˜ê°€ ì—†ì„ ê²½ìš°), í•´ë‹¹ ì¸ë±ìŠ¤ì— í•´ë‹¹í•˜ëŠ” Text ì»´í¬ë„ŒíŠ¸ì˜ text ì†ì„±ì„ ë¹„ì›Œë‘”ë‹¤.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
                gIngredient_cnt[i].GetComponent<Text>().text = "";
            }
       }
    }
    public void UpdateRecipeUI()
    {
<<<<<<< HEAD
        for (int i = 0; i < 4; i++)     // 0ºÎÅÍ 3±îÁöÀÇ ÀÎµ¦½º¸¦ »ç¿ëÇÏ¿© ¹Ýº¹
        {
            try
            {
                // ingredientImages[i].enabled = true;¸¦ »ç¿ëÇÏ¿© ingredientImages ¹è¿­¿¡¼­
                // ÇöÀç ÀÎµ¦½º¿¡ ÇØ´çÇÏ´Â Image ÄÄÆ÷³ÍÆ®ÀÇ È°¼ºÈ­ »óÅÂ¸¦ true·Î ¼³Á¤
                // enabled´Â UnityÀÇ ÄÄÆ÷³ÍÆ®³ª °ÔÀÓ ¿ÀºêÁ§Æ®ÀÇ È°¼ºÈ­ ¿©ºÎ¸¦ ³ªÅ¸³»´Â ¼Ó¼º
                ingredientImages[i].enabled = true;

                // recipeSprites ¹è¿­¿¡¼­ ·¹½ÃÇÇ½ºÅ©¸³Æ®ÀÇ ·¹½ÃÇÇ ÀÎµ¦½º °ª¿¡ ÇØ´çÇÏ´Â ½ºÇÁ¶óÀÌÆ®·Î ¼³Á¤
                recipeImage.sprite = recipeSprites[Recipe.RecipeIndex];

                // Àç·á ÀÌ¹ÌÁö ¹è¿­¿¡¼­ ÀÜ¿© ·¹½ÃÇÇÀÇ Å°(Àç·á)¸¦ °¡Á®¿Â ÈÄ Å°¿¡ ÇØ´çÇÏ´Â Àç·á ÀÌ¹ÌÁö ½ºÇÁ¶óÀÌÆ® Àû¿ë
=======
        for (int i = 0; i < 4; i++)     // 0ë¶€í„° 3ê¹Œì§€ì˜ ì¸ë±ìŠ¤ë¥¼ ì‚¬ìš©í•˜ì—¬ ë°˜ë³µ
        {
            try
            {
                // ingredientImages[i].enabled = true;ë¥¼ ì‚¬ìš©í•˜ì—¬ ingredientImages ë°°ì—´ì—ì„œ
                // í˜„ìž¬ ì¸ë±ìŠ¤ì— í•´ë‹¹í•˜ëŠ” Image ì»´í¬ë„ŒíŠ¸ì˜ í™œì„±í™” ìƒíƒœë¥¼ trueë¡œ ì„¤ì •
                // enabledëŠ” Unityì˜ ì»´í¬ë„ŒíŠ¸ë‚˜ ê²Œìž„ ì˜¤ë¸Œì íŠ¸ì˜ í™œì„±í™” ì—¬ë¶€ë¥¼ ë‚˜íƒ€ë‚´ëŠ” ì†ì„±
                ingredientImages[i].enabled = true;

                // recipeSprites ë°°ì—´ì—ì„œ ë ˆì‹œí”¼ìŠ¤í¬ë¦½íŠ¸ì˜ ë ˆì‹œí”¼ ì¸ë±ìŠ¤ ê°’ì— í•´ë‹¹í•˜ëŠ” ìŠ¤í”„ë¼ì´íŠ¸ë¡œ ì„¤ì •
                recipeImage.sprite = recipeSprites[Recipe.RecipeIndex];

                // ìž¬ë£Œ ì´ë¯¸ì§€ ë°°ì—´ì—ì„œ ìž”ì—¬ ë ˆì‹œí”¼ì˜ í‚¤(ìž¬ë£Œ)ë¥¼ ê°€ì ¸ì˜¨ í›„ í‚¤ì— í•´ë‹¹í•˜ëŠ” ìž¬ë£Œ ì´ë¯¸ì§€ ìŠ¤í”„ë¼ì´íŠ¸ ì ìš©
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
                ingredientImages[i].sprite = ingredientSprites[Recipe.ShowLeftoverRecipe().Keys.ToList()[i]];
            }
            catch
            {
<<<<<<< HEAD
                //¸¸¾à ¿¹¿Ü°¡ ¹ß»ýÇÑ´Ù¸é ingredientImages ¹è¿­¿¡¼­ ÇöÀç ÀÎµ¦½º¿¡ ÇØ´çÇÏ´Â Image ÄÄÆ÷³ÍÆ®ÀÇ È°¼ºÈ­ »óÅÂ¸¦ false·Î ¼³Á¤
=======
                //ë§Œì•½ ì˜ˆì™¸ê°€ ë°œìƒí•œë‹¤ë©´ ingredientImages ë°°ì—´ì—ì„œ í˜„ìž¬ ì¸ë±ìŠ¤ì— í•´ë‹¹í•˜ëŠ” Image ì»´í¬ë„ŒíŠ¸ì˜ í™œì„±í™” ìƒíƒœë¥¼ falseë¡œ ì„¤ì •
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
                ingredientImages[i].enabled = false;
            }
        }
    } 

    private void UpdateHearthp()
    {
<<<<<<< HEAD
        for (int i = 0; i < maxHp; i++)             //0ºÎÅÍ maxHp(3)±îÁöÀÇ ÀÎµ¦½º¸¦ »ç¿ëÇÏ¿© ¹Ýº¹
        {
            if (i < hp)                             // hp°¡ iº¸´Ù ÀÛÀ» °æ¿ì
            {
                heartImages[i].enabled = true;      // enabled = true¸¦ »ç¿ëÇÏ¿© hpÀÌ¹ÌÁö ¹è¿­À» UI·Î ³ªÅ¸³½´Ù.
            }
            else
            {
                heartImages[i].enabled = false;     // ±×°Ô ¾Æ´Ï¶ó¸é hp ÀÌ¹ÌÁö ¹è¿­ UI¸¦ ºñÈ°¼ºÈ­ ½ÃÅ´
=======
        for (int i = 0; i < maxHp; i++)             //0ë¶€í„° maxHp(3)ê¹Œì§€ì˜ ì¸ë±ìŠ¤ë¥¼ ì‚¬ìš©í•˜ì—¬ ë°˜ë³µ
        {
            if (i < hp)                             // hpê°€ ië³´ë‹¤ ìž‘ì„ ê²½ìš°
            {
                heartImages[i].enabled = true;      // enabled = trueë¥¼ ì‚¬ìš©í•˜ì—¬ hpì´ë¯¸ì§€ ë°°ì—´ì„ UIë¡œ ë‚˜íƒ€ë‚¸ë‹¤.
            }
            else
            {
                heartImages[i].enabled = false;     // ê·¸ê²Œ ì•„ë‹ˆë¼ë©´ hp ì´ë¯¸ì§€ ë°°ì—´ UIë¥¼ ë¹„í™œì„±í™” ì‹œí‚´
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
            }
        }
    }

    public void ActivateGameover()
    {
<<<<<<< HEAD
        Gameover_Panel.SetActive(true);             // SetActive¸Þ¼­µå¸¦ È°¿ëÇÏ¿© ÇØ´ç GameoverÆÇ³Ú ¿ÀºêÁ§Æ®¸¦ true(È°¼ºÈ­) ½ÃÅ²´Ù.
=======
        Gameover_Panel.SetActive(true);             // SetActiveë©”ì„œë“œë¥¼ í™œìš©í•˜ì—¬ í•´ë‹¹ GameoveríŒë„¬ ì˜¤ë¸Œì íŠ¸ë¥¼ true(í™œì„±í™”) ì‹œí‚¨ë‹¤.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    public void GameOverChange()
    {
<<<<<<< HEAD
        SceneDirector.ChangeScene2();               // °ÔÀÓ¿À¹ö ½Ã ¾À µð·ºÅÍÀÇ ChangeScene2ÇÔ¼ö¸¦ ½ÇÇàÇÑ´Ù(finishScene ÀüÈ¯)
=======
        SceneDirector.ChangeScene2();               // ê²Œìž„ì˜¤ë²„ ì‹œ ì”¬ ë””ë ‰í„°ì˜ ChangeScene2í•¨ìˆ˜ë¥¼ ì‹¤í–‰í•œë‹¤(finishScene ì „í™˜)
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }
} 