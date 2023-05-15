using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    // Define ingredients
    private int i1;
    private int i2;
    private int i3;
    private int i4;
    private int i5;

    // Define recipes
    private int r1;
    private int r2;
    private int r3;

    // Randomly generate ingredient values between 1 and 10
    private void GenerateIngredients()
    {
        System.Random random = new System.Random();
        i1 = random.Next(1, 11);
        i2 = random.Next(1, 11);
        i3 = random.Next(1, 11);
        i4 = random.Next(1, 11);
        i5 = random.Next(1, 11);
    }

    // Randomly generate recipe values between 1 and 10
    private void GenerateRecipes()
    {
        System.Random random = new System.Random();
        r1 = random.Next(1, 11);
        r2 = random.Next(1, 11);
        r3 = random.Next(1, 11);
    }

    // Check if the recipe is complete based on ingredient values
    private bool IsRecipeComplete()
    {
        return (i1 >= r1 && i2 >= r2 && i3 >= r3);
    }

    // Start is called before the first frame update
    private void Start()
    {
        GenerateIngredients();
        GenerateRecipes();

        if (IsRecipeComplete())
        {
            Debug.Log("Recipe is complete!");
        }
        else
        {
            Debug.Log("Recipe is incomplete.");
        }
    }
}
