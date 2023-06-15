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
<<<<<<< HEAD
=======
    green_onion,
>>>>>>> 1462d7f0dc647633f5280c97ac77c37cb3af07b7
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
    public int SuccessRecipe = 0;
=======

    public static int RecipeIndex = 0;

>>>>>>> 1462d7f0dc647633f5280c97ac77c37cb3af07b7
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
        r1 = new int[ingredientAmt] { 1, 0, 0, 0, 0, 1, 1 };  // ·¹½ÃÇÇ 1: beef + onion + carrot
        r2 = new int[ingredientAmt] { 0, 1, 0, 1, 1, 1, 0 };  // ·¹½ÃÇÇ 2: chicken + onion + depa + egg
        r3 = new int[ingredientAmt] { 0, 0, 1, 1, 0, 1, 0 };  // ·¹½ÃÇÇ 3: fish + depa + onion
=======
        r1 = new int[ingredientAmt] { 2, 0, 0, 0, 0, 1, 1 };  // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ 1: beef + onion + carrot
        r2 = new int[ingredientAmt] { 0, 1, 0, 1, 1, 1, 0 };  // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ 2: chicken + onion + depa + egg
        r3 = new int[ingredientAmt] { 0, 0, 1, 1, 0, 1, 0 };  // ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ 3: fish + depa + onion
>>>>>>> 1462d7f0dc647633f5280c97ac77c37cb3af07b7
        randomRecipe = new int[ingredientAmt];
    }

    // Recioe random raw
    public int createRandomRecipe()
    {
        int randomIndex = Random.Range(0, 7);

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
<<<<<<< HEAD
        createRandomRecipe();
=======
        RecipeIndex = createRandomRecipe();
>>>>>>> 1462d7f0dc647633f5280c97ac77c37cb3af07b7
    }

    private void Update()
    {        // Recipe reset status
        if (IsRecipeComplete(randomRecipe) || IsRecipeWrong(randomRecipe))
        {
            init();
<<<<<<< HEAD
            createRandomRecipe();
            /*            Debug.Log("·¹½ÃÇÇ ´Ù½Ã »ý¼º");*/
            gameDirector.GetComponent<GameDirector>().UpdateUI(gameDirector.GetComponent<GameDirector>().GetRecipeIndex());
            if (IsRecipeComplete(randomRecipe))
            {
                while(SuccessRecipe != 9)
                {
                    SuccessRecipe++;
                    break;
                }
                
=======
            RecipeIndex = createRandomRecipe();
            /*            Debug.Log("ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½Ù½ï¿½ ï¿½ï¿½ï¿½ï¿½");*/
            gameDirector.GetComponent<GameDirector>().UpdateUI(gameDirector.GetComponent<GameDirector>().GetIngredientIndex());
            if (IsRecipeComplete(randomRecipe))
            {
>>>>>>> 1462d7f0dc647633f5280c97ac77c37cb3af07b7
                // Success Performance;
            }
            else
            {
                // Fail Performance;
            }
        }
    }
}