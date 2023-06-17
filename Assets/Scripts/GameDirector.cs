using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class GameDirector : MonoBehaviour
{
    [SerializeField] public int maxHp = 5;
    [SerializeField] public Image[] heartImages;
    [SerializeField] GameObject[] gIngredient_cnt;
    [SerializeField] public GameObject Gameover_Panel;

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
        UpdateRecipeUI();

        if (GameDirector.hp <= 0)
        {
            Invoke("ActivateGameover", 3f);
            Invoke("GameOverChange", 5f);
        }
    }

    public void UpdateRecipeCnt()
    {
        for (int i = 0; i < 4; i++)
        {   
            try{
/*                Debug.Log("Cnt" + Recipe.ShowLeftoverRecipe().Values.ToList()[i]);*/
                gIngredient_cnt[i].GetComponent<Text>().text = "x" + Recipe.ShowLeftoverRecipe().Values.ToList()[i];
            }
            catch
            {
/*                Debug.Log(i + ": cnt is null");*/
                gIngredient_cnt[i].GetComponent<Text>().text = "";
            }
       }
    }
    public void UpdateRecipeUI()
    {
        for (int i = 0; i < 4; i++)
        {
            try
            {
/*                Debug.Log("UI"  +Recipe.ShowLeftoverRecipe().Keys.ToList()[i]);*/
                ingredientImages[i].enabled = true;
                recipeImage.sprite = recipeSprites[Recipe.RecipeIndex];
                ingredientImages[i].sprite = ingredientSprites[Recipe.ShowLeftoverRecipe().Keys.ToList()[i]];
            }
            catch
            {
/*                Debug.Log(i + ": img is null");*/
                ingredientImages[i].enabled = false;
            }
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

    public void GameOverChange()
    {
        SceneDirector.ChangeScene2();
    }
}