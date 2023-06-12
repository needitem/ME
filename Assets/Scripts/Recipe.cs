using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Ingredients
{
    beef,
    chicken,
    fish,
    depa,
    egg,
    onion,
    carrot
}

public class Recipe : MonoBehaviour
{
    // Define recipes
    GameObject gameDirector;
    const int ingredientAmt = 7;
    private int[] r1;
    private int[] r2;
    private int[] r3;
    public static int[] randomRecipe = new int[ingredientAmt];

    public static int RecipeIndex = 0;

    public bool IsRecipeComplete(int[] randomRecipe)
    {
        foreach (int i in randomRecipe)
        {
            if (i > 0)
            {
                return false;
            }
        }
        return true;
    }

    public bool IsRecipeWrong(int[] randomRecipe)
    {
        foreach (int i in randomRecipe)
        {
            if (i < 0)
            {
                return true;
            }
        }
        return false;
    }

    public void init()
    {
        r1 = new int[ingredientAmt] { 2, 0, 0, 0, 0, 1, 1 };  // 레시피 1: beef + onion + carrot
        r2 = new int[ingredientAmt] { 0, 1, 0, 1, 1, 1, 0 };  // 레시피 2: chicken + onion + depa + egg
        r3 = new int[ingredientAmt] { 0, 0, 1, 1, 0, 1, 0 };  // 레시피 3: fish + depa + onion
        randomRecipe = new int[ingredientAmt];
    }

    // Recioe random raw
    public int createRandomRecipe()
    {
        int randomIndex = Random.Range(0, 3);

        switch (randomIndex)
        {
            case 0: randomRecipe = r1; break;
            case 1: randomRecipe = r2; break;
            case 2: randomRecipe = r3; break;
        }
        return randomIndex;
    }

    public void showLeftoverRecipe()
    {
        //display
    }

    public static void decreaseIngredient(string name)
    {
        Ingredients ingredient = (Ingredients)Enum.Parse(typeof(Ingredients), name);
        int index = (int)ingredient;
        randomRecipe[index]--;
        /*        Debug.Log(index);
                Debug.Log(randomRecipe[index]);
                Debug.Log(ingredient);*/
    }

    private void Start()
    {
        gameDirector = GameObject.Find("GameDirector");
        init();
        RecipeIndex = createRandomRecipe();
    }

    private void Update()
    {        // Recipe reset status
        if (IsRecipeComplete(randomRecipe) || IsRecipeWrong(randomRecipe))
        {
            init();
            RecipeIndex = createRandomRecipe();
            /*            Debug.Log("레시피 다시 생성");*/
            gameDirector.GetComponent<GameDirector>().UpdateUI(gameDirector.GetComponent<GameDirector>().GetIngredientIndex());
            if (IsRecipeComplete(randomRecipe))
            {
                // Success Performance;
            }
            else
            {
                // Fail Performance;
            }
        }
    }
}