using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    // to reduce hp
    GameObject player = null;

    // Define recipes
    const int ingredientAmt = 3;
    private int[] r1 = new int[ingredientAmt] { 1, 2, 3 };
    private int[] r2 = new int[ingredientAmt] { 1, 2, 3 };
    private int[] r3 = new int[ingredientAmt] { 1, 2, 3 };
    private int[] randomRecipe = new int[ingredientAmt];

    //  recipe reset
    public void init()
    {
        r1 = new int[ingredientAmt] { 1, 2, 3 };
        r2 = new int[ingredientAmt] { 1, 2, 3 };
        r3 = new int[ingredientAmt] { 1, 2, 3 };
        randomRecipe = new int[ingredientAmt];
    }

    // Check if the recipe is complete based on ingredient values
    // Recipe Completion status
    public int IsRecipeComplete(int[] randomRecipe)
    {
        int[] bit_array = { 0, 0, 0 };
        int bit = 0;
        
        // Recipe check 
        for (int i = 0; i < bit_array.Length; i++)
        {
            if (randomRecipe[i] < 0)
            {
                bit_array[i] = 1;
            }
            else bit_array[i] = 0;
        }

        bit = bit_array[0] + bit_array[1] + bit_array[2];
        
        // Recipe Success
        if (randomRecipe[0] == 0 && randomRecipe[1] == 0 && randomRecipe[2] == 0)
        {
            bit = 1;
        }
        return bit;
    }
    
    // Recioe random raw
    public void createRandomRecipe()
    {
        int randomIndex = Random.Range(0, 3);

        switch (randomIndex)
        {
            case 0: randomRecipe = this.r1; break; 
            case 1: randomRecipe = this.r2; break;
            case 2: randomRecipe = this.r3; break;
        }
    }
    private void Start()
    {
        player = GameObject.Find("Player");
        createRandomRecipe();
    }

    private void Update()
    {
        // Recipe reset status
        if (IsRecipeComplete(randomRecipe) == 1)
        {
            player.GetComponent<Animator>().SetTrigger("damaged");
            GameDirector.hp--;
            init();
            createRandomRecipe();
            Debug.Log("[0]" + randomRecipe[0] + "[1]" + randomRecipe[1] + "[2]" + randomRecipe[2]);
        }
    }
}