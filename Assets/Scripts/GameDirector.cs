using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [SerializeField] public int maxHp = 5;
    [SerializeField] public Image[] heartImages;
    [SerializeField] public GameObject Gameover_Panel;
    [SerializeField] GameObject[] gIngredient_cnt;

    public Recipe recipe;
    public Image recipeImage;
    public Image[] ingredientImages;

    public Sprite[] recipeSprites;
    public Sprite[] ingredientSprites;


    static public int hp;

    // Start is called before the first frame update

    void Start()
    {
        hp = maxHp;
        Time.timeScale = 1;
        UpdateRecipeUI();
        UpdateRecipeCnt();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHearthp();
        UpdateRecipeCnt();
        /*UpdateRecipeUI();*/
        if (hp <= 0)
        {
            Invoke("ActivateGameover", 3f);
            Invoke("ChangeScene2", 5f);
        }
        /*        Dictionary<int, int> temp = Recipe.showLeftoverRecipe();*/

        /*        for (int i = 0; i < 4; i++)
                {
                    
                }*/

    }

    public void UpdateRecipeCnt()
    {
        Dictionary<int, int> leftoverRecipe = Recipe.showLeftoverRecipe(); 
        int[] rearrangedRecipe = new int[gIngredient_cnt.Length]; 

        int currentIndex = 0; 
        foreach (var pair in leftoverRecipe) 
        {
            int ingredientCount = pair.Value;   
            rearrangedRecipe[currentIndex] = ingredientCount;
            currentIndex++;
        }

        for (int i = 0; i < gIngredient_cnt.Length; i++)
        {
            if (i < currentIndex)
            {
                gIngredient_cnt[i].GetComponent<Text>().text = "x" + rearrangedRecipe[i];
            }
            else
            {
                gIngredient_cnt[i].GetComponent<Text>().text = "x0";
            }
        }
    }





    public void UpdateRecipeUI()
    {
        int j = 0;
        // recipe img update
        recipeImage.sprite = recipeSprites[Recipe.RecipeIndex];

        // ingredient img update
        foreach (KeyValuePair<int, int> item in Recipe.showLeftoverRecipe())
        {
            ingredientImages[j].sprite = ingredientSprites[item.Key];
            j++;
        }
        /* Key : ingredient ÀÎµ¦½º°ª, Value : ingredient °¹¼ö*/
    }


    private void UpdateHearthp()
    {
        for (int i = 0; i < maxHp; i++)
        {
            if (i < hp)
            {
                heartImages[i].enabled = true;
            }
            else
            {
                heartImages[i].enabled = false;
            }
        }
    }


    public void ActivateGameover()
    {
        Gameover_Panel.SetActive(true);
    }

    public void ChangeScene1()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ChangeScene2()
    {
        SceneManager.LoadScene("FinishScene");
    }

    public void ChangeScene3()
    {
        SceneManager.LoadScene("TitleScene");
    }
}