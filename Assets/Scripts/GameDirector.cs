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
<<<<<<< HEAD
        }

<<<<<<< HEAD
        /*        gIngredient_cnt[0].GetComponent<Text>().text = "X" + valueArray[0].ToString("D2"); //adsf
                gIngredient_cnt[1].GetComponent<Text>().text = "X" + valueArray[1].ToString("D2");
                gIngredient_cnt[2].GetComponent<Text>().text = "X" + valueArray[2].ToString("D2");
                gIngredient_cnt[3].GetComponent<Text>().text = "X" + valueArray[3].ToString("D2");*/

    }


=======
        gIngredient_cnt[0].GetComponent<Text>().text = "X" + Recipe.randomRecipe[indexArray[0]].ToString("D1");
        gIngredient_cnt[1].GetComponent<Text>().text = "X" + Recipe.randomRecipe[indexArray[1]].ToString("D1");
        gIngredient_cnt[2].GetComponent<Text>().text = "X" + Recipe.randomRecipe[indexArray[2]].ToString("D1");
        gIngredient_cnt[3].GetComponent<Text>().text = "X" + Recipe.randomRecipe[indexArray[3]].ToString("D1");
    }

>>>>>>> 1462d7f0dc647633f5280c97ac77c37cb3af07b7
    public void UpdateUI(int[] indexArray)
=======
        }        
    }

    public void UpdateRecipeUI()
>>>>>>> 037113a09a7e88abd2eaff2a99f17905796a941d
    {
        int j = 0;
<<<<<<< HEAD
<<<<<<< HEAD
        int recipeIndex = GetRecipeIndex(Recipe.randomRecipe);
=======
        int recipeIndex = Recipe.RecipeIndex;
>>>>>>> 1462d7f0dc647633f5280c97ac77c37cb3af07b7
        recipeImage.sprite = recipeSprites[recipeIndex];

=======
        // recipe img update
        recipeImage.sprite = recipeSprites[Recipe.RecipeIndex];
>>>>>>> 037113a09a7e88abd2eaff2a99f17905796a941d

        // ingredient img update
        foreach (KeyValuePair<int, int> item in Recipe.ShowLeftoverRecipe())
        {
            ingredientImages[j].sprite = ingredientSprites[item.Key];
            j++;
        }
        /* Key : ingredient �ε�����, Value : ingredient ����*/
    }

<<<<<<< HEAD
<<<<<<< HEAD
    public int[] GetRecipeIndex()
=======
    public int[] GetIngredientIndex()
>>>>>>> 1462d7f0dc647633f5280c97ac77c37cb3af07b7
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
<<<<<<< HEAD

=======
>>>>>>> 1462d7f0dc647633f5280c97ac77c37cb3af07b7
        return indexArray;
    }


<<<<<<< HEAD
    public static int GetRecipeIndex(int[] recipe)
    {
        for (int i = 0; i < recipe.Length; i++)
        {
            if (recipe[i] > 0)
            {
                return i;
            }
        }
        return 0;
    }


    private void UpdateHearthp()
    {
=======


=======
>>>>>>> 037113a09a7e88abd2eaff2a99f17905796a941d

    private void UpdateHearthp()
    {
>>>>>>> 1462d7f0dc647633f5280c97ac77c37cb3af07b7
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