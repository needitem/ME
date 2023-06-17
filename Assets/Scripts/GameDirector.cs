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
        UpdateRecipeCnt();
        UpdateRecipeUI();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHearthp();
        UpdateRecipeCnt();
        if (hp <= 0)
        {
            Invoke("ActivateGameover", 3f);
            Invoke("ChangeScene2", 5f);
        }
    }

    public void UpdateRecipeCnt()
    {
        int i = 0;

        foreach (KeyValuePair<int, int> item in Recipe.ShowLeftoverRecipe())
        {
            gIngredient_cnt[i].GetComponent<Text>().text = (Recipe.randomRecipe[item.Key] == 0) ? "0" : "x" + Recipe.randomRecipe[item.Key].ToString();
            i++;
        }
    }
    public void UpdateRecipeUI()
    {
        int j = 0;
        // recipe img update
        recipeImage.sprite = recipeSprites[Recipe.RecipeIndex];

        // ingredient img update
        foreach (KeyValuePair<int, int> item in Recipe.ShowLeftoverRecipe())
        {
            ingredientImages[j].sprite = ingredientSprites[item.Key];
            j++;
/*            if (ingredientImages[j+1].sprite == null)
            {
                ingredientImages[j+1].gameObject.SetActive(false);
            }*/
        }
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