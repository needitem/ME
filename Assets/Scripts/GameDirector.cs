using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    void Start()
    {
        hp = maxHp;
        Time.timeScale = 1;
        UpdateRecipeUI();
    }

    void Update()
    {
        UpdateHearthp();
        UpdateRecipeUI();
        if (hp <= 0)
        {
            Invoke("ActivateGameover", 3f);
        }
  }

    public void UpdateRecipeUI()
    {
        // Update the recipe image
        recipeImage.sprite = recipeSprites[Recipe.RecipeIndex];

        // Get the leftover recipe items
        List<KeyValuePair<int, int>> leftoverRecipe = new List<KeyValuePair<int, int>>(Recipe.ShowLeftoverRecipe());

        // Update the ingredient counts and images
        for (int j = 0; j < leftoverRecipe.Count; j++)
        {
            KeyValuePair<int, int> item = leftoverRecipe[j];
            gIngredient_cnt[j].GetComponent<Text>().text = "x" + item.Value;
            ingredientImages[j].sprite = ingredientSprites[item.Key];
        }
    }


    private void UpdateHearthp()
    {
        for (int i = 0; i < maxHp; i++)
        {
            heartImages[i].enabled = i < hp;
        }
    }
    public void ActivateGameover()
    {
        Gameover_Panel.SetActive(true);
    }
}