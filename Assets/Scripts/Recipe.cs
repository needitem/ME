using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Ingredients
{
    egg,
    red,
    yellow
}
public class Recipe : MonoBehaviour
{
    // to reduce hp
    GameObject player = null;

    // Define recipes
    const int ingredientAmt = 3;
    private int[] r1;
    private int[] r2;
    private int[] r3;
    private int[] randomRecipe;


    public bool IsRecipeComplete(int[] randomRecipe)
    {
        foreach(int i in randomRecipe)
        {
            if (i > 0)
            {
                return false;
            }
        }
        return true;
    }

    // Recioe random raw
    public void createRandomRecipe()
    {
        int randomIndex = Random.Range(0, 3);

        switch (randomIndex)
        {
            case 0: randomRecipe = r1; break;
            case 1: randomRecipe = r2; break;
            case 2: randomRecipe = r3; break;
        }
    }

    public void showRecipe()
    {
        //display randomRecipe
    }

    public static void decreaseIngredient(string name)
    {
        Ingredients ingredient = (Ingredients)Enum.Parse(typeof(Ingredients), name);  
        Debug.Log(ingredient);  
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        r1 = new int[ingredientAmt] { 1, 2, 3 };
        r2 = new int[ingredientAmt] { 1, 2, 3 };
        r3 = new int[ingredientAmt] { 1, 2, 3 };
        randomRecipe = new int[ingredientAmt];
        createRandomRecipe();
    }

    private void Update()
    {        // Recipe reset status
        if (IsRecipeComplete(randomRecipe))
        {
            createRandomRecipe();
        }
    }
}