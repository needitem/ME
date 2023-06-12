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

<<<<<<< HEAD
=======
    public static int RecipeIndex = 0;

>>>>>>> 766af1bccbed5d26b5e3ad685556ce731b5139c8
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
<<<<<<< HEAD
        r1 = new int[ingredientAmt] { 1, 0, 0, 0, 0, 1, 1 };  // 레시피 1: beef + onion + carrot
=======
        r1 = new int[ingredientAmt] { 2, 0, 0, 0, 0, 1, 1 };  // 레시피 1: beef + onion + carrot
>>>>>>> 766af1bccbed5d26b5e3ad685556ce731b5139c8
        r2 = new int[ingredientAmt] { 0, 1, 0, 1, 1, 1, 0 };  // 레시피 2: chicken + onion + depa + egg
        r3 = new int[ingredientAmt] { 0, 0, 1, 1, 0, 1, 0 };  // 레시피 3: fish + depa + onion
        randomRecipe = new int[ingredientAmt];
    }

    // Recioe random raw
<<<<<<< HEAD
    public void createRandomRecipe()
    {
        int randomIndex = Random.Range(0, 7);
=======
    public int createRandomRecipe()
    {
        int randomIndex = Random.Range(0, 3);
>>>>>>> 766af1bccbed5d26b5e3ad685556ce731b5139c8

        switch (randomIndex)
        {
            case 0: randomRecipe = r1; break;
            case 1: randomRecipe = r2; break;
            case 2: randomRecipe = r3; break;
        }
<<<<<<< HEAD
=======
        return randomIndex;
>>>>>>> 766af1bccbed5d26b5e3ad685556ce731b5139c8
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
<<<<<<< HEAD
        createRandomRecipe();
=======
        RecipeIndex = createRandomRecipe();
>>>>>>> 766af1bccbed5d26b5e3ad685556ce731b5139c8
    }

    private void Update()
    {        // Recipe reset status
        if (IsRecipeComplete(randomRecipe) || IsRecipeWrong(randomRecipe))
        {
            init();
<<<<<<< HEAD
            createRandomRecipe();
            /*            Debug.Log("레시피 다시 생성");*/
            gameDirector.GetComponent<GameDirector>().UpdateUI(gameDirector.GetComponent<GameDirector>().GetRecipeIndex());
=======
            RecipeIndex = createRandomRecipe();
            /*            Debug.Log("레시피 다시 생성");*/
            gameDirector.GetComponent<GameDirector>().UpdateUI(gameDirector.GetComponent<GameDirector>().GetIngredientIndex());
>>>>>>> 766af1bccbed5d26b5e3ad685556ce731b5139c8
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