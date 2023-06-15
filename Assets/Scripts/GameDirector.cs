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
    public int[] indexArray = new int[Recipe.randomRecipe.Length];
    public int[] valueArray = new int[Recipe.randomRecipe.Length];
    // Start is called before the first frame update

    void Start()
    {
        hp = maxHp;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHearthp();
        /*UpdateRecipeUI();*/
        if (hp <= 0)
        {
            Invoke("ActivateGameover", 3f);
        }
    }

    public void UpdateRecipeUI()
    {
        // recipe img update
        int j = 0;
        int recipeIndex = Recipe.RecipeArray[0];
        recipeImage.sprite = recipeSprites[recipeIndex];

        // ingredient img update
        for (int i = 1; i < Recipe.RecipeArray.Length; i++)
        {
            int index = indexArray[i];
            ingredientImages[j].sprite = ingredientSprites[index];
            j++;
            //ingredientImages[i].gameObject.SetActive(Recipe.randomRecipe[i] > 0);
        }
    }
    // RecipeArray = 
    /*    public int[] GetIngredientIndex()
        {
            int j = 0;
            int previousIndex = 0;

            for (int i = 0; i < Recipe.randomRecipe.Length; i++)
            {
                if (Recipe.randomRecipe[i] > 0)
                {
                    indexArray[j] = previousIndex;
                    valueArray[j] = Recipe.randomRecipe[i];
                    j++;
                }
                previousIndex++;
            }
            return indexArray;
        }*/



    /*    public void UpdateUI1(int[] RecipeArray)
        {
            int j = 0;
            int recipeIndex = RecipeArray[0];
            recipeImage.sprite = recipeSprites[recipeIndex];

            for (int i = 1; i < RecipeArray.Length - 1; i++)
            {
                ingredientImages[j].sprite = ingredientSprites[i];
                j++;
            }
        }*/


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

    public void changeScene1()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void changeScene2()
    {
        SceneManager.LoadScene("FinishScene");
    }

    public void changeScene3()
    {
        SceneManager.LoadScene("TitleScene");
    }
}