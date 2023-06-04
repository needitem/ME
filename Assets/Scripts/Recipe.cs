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

    // Conflict with recipe
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().name.Contains("Yellow") == true)
        {
            randomRecipe[0] += -1;
            Debug.Log("[0] : " + randomRecipe[0]);
        }

        if (other.GetComponent<Collider2D>().name.Contains("Green") == true)
        {
            randomRecipe[1] += -1;
            Debug.Log("[1] : " + randomRecipe[1]);
        }

        if (other.GetComponent<Collider2D>().name.Contains("Red") == true)
        {
            randomRecipe[2] += -1;
            Debug.Log("[2] : " + randomRecipe[2]);
        }
        Destroy(other.gameObject);
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
        player = GameObject.Find("Player");
        OffRecipeCollision();
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