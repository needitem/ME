using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    const int ingredientAmt = 3;
    private int Complete = 0;


    // Define recipes
    private int[] r1 = new int[ingredientAmt] { 1, 2, 3 };
    private int[] r2 = new int[ingredientAmt] { 1, 2, 3 };
    private int[] r3 = new int[ingredientAmt] { 1, 2, 3 };
    private static int[] randomRecipe = new int[ingredientAmt];

    // Check if the recipe is complete based on ingredient values
    // Recipe Completion status
    public int IsRecipeComplete(int[] randomRecipe)
    {
        int bit0 = 0;
        int bit1 = 0;
        int bit2 = 0;
        int bit = 1;

        if (randomRecipe[0] < 0) bit0 = 1;
        else bit0 = 0;

        if (randomRecipe[1] < 0) bit1 = 1;
        else bit1 = 0;
            
        if (randomRecipe[2] < 0) bit2 = 1;
        else bit2 = 0;

        bit = bit0 + bit1 + bit2;

        if (randomRecipe[0] == 0 && randomRecipe[1] == 0 && randomRecipe[2] == 0){
            bit = 1;
        }

        return bit;
    }

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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Contains("Yellow") == true)
        {
            randomRecipe[0] += -1;
            Debug.Log("[0] : " + randomRecipe[0]);
        }

        if (collider.name.Contains("Green") == true)
        {
            randomRecipe[1] += -1;
            Debug.Log("[1] : " + randomRecipe[1]);
        }

        if (collider.name.Contains("Red") == true)
        {
            randomRecipe[2] += -1;
            Debug.Log("[2] : " + randomRecipe[2]);
        }         
    }

    // Recipe Collision ON/OFF Method
    public void OffRecipeCollision()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void OnRecipeCollision()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        Invoke("OffRecipeCollision", 0.4f);
    }

    private void Start()
    {
        OffRecipeCollision();
        createRandomRecipe();
    }

    private void Update()
    {
        if (IsRecipeComplete(randomRecipe) >= 1)
        {
            createRandomRecipe();
            Debug.Log(randomRecipe[0] + randomRecipe[1] + randomRecipe[2]);
        }  
    }
}