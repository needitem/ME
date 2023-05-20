using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    const int ingredientAmt = 5;
    // Define recipes
    private int[] r1 = new int[ingredientAmt] { 1, 2, 3, 4, 5 };
    private int[] r2 = new int[ingredientAmt] { 3, 2, 1, 5, 4 };
    private int[] r3 = new int[ingredientAmt] { 6, 5, 4, 2, 3 };

    // Check if the recipe is complete based on ingredient values
    public bool IsRecipeComplete(int[] recipe)
    {
        foreach (int r in recipe)
        {
            if (r>0) return false;
        }
        return true;
    }

    public int[] RandomRecipe()
    {
        int randomIndex = Random.Range(1, 4);
        int[] randomRecipe = new int[ingredientAmt];

        switch (randomIndex)
        {
            case 0: randomRecipe = r1; break;
            case 1: randomRecipe = r2; break;
            case 2: randomRecipe = r3; break;
        }
        return randomRecipe;
    }
}
