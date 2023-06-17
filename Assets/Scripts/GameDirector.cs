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
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHearthp();
        if (hp <= 0)
        {
            Invoke("ActivateGameover", 3f);
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
        }
        /* Key : ingredient �ε�����, Value : ingredient ����*/
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