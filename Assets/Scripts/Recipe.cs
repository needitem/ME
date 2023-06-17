using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Ingredients
{
    beef,
    chicken,
    fish,
    green_onion,
    egg,
    onion,
<<<<<<< HEAD
<<<<<<< HEAD
=======
    green_onion,
>>>>>>> 1462d7f0dc647633f5280c97ac77c37cb3af07b7
=======
>>>>>>> 037113a09a7e88abd2eaff2a99f17905796a941d
    carrot
}

public class Recipe : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    [SerializeField] private GameObject gameDirector;
    private const int ingredientAmt = 7;
    private readonly int[] recipe1 = { 20, 0, 0, 0, 0, 10, 10 };
    private readonly int[] recipe2 = { 0, 10, 0, 10, 10, 10, 0 };
    private readonly int[] recipe3 = { 0, 0, 10, 10, 0, 10, 0 };
    private static readonly int[] randomRecipe = new int[ingredientAmt];
>>>>>>> 037113a09a7e88abd2eaff2a99f17905796a941d

    public static int RecipeIndex { get; private set; }

<<<<<<< HEAD
>>>>>>> 1462d7f0dc647633f5280c97ac77c37cb3af07b7
    public bool IsRecipeComplete(int[] randomRecipe)
=======
    public bool IsRecipeComplete(int[] randomRecipe) // check if recipe is complete, return true if complete, return false if not
>>>>>>> 037113a09a7e88abd2eaff2a99f17905796a941d
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

    public bool IsRecipeWrong(int[] randomRecipe) // check if recipe is wrong, return true if wrong, return false if not
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

    private void Awake() // initialize randomRecipe
    {
<<<<<<< HEAD
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
=======
        Init();
        gameDirector = GameObject.Find("GameDirector");
        RecipeIndex = CreateRandomRecipe();
>>>>>>> 037113a09a7e88abd2eaff2a99f17905796a941d
    }

    private void Update()
    {
        if (IsRecipeComplete(randomRecipe) || IsRecipeWrong(randomRecipe)) // if recipe is complete or wrong, create new recipe
        {
            Init();
            RecipeIndex = CreateRandomRecipe();
            gameDirector.GetComponent<GameDirector>().UpdateRecipeUI();
            if (IsRecipeComplete(randomRecipe))
            {
                //RecipeIndex = CreateRandomRecipe();
                //Need to add score, speedup, etc
            }
            else if (IsRecipeWrong(randomRecipe))
            {
               //GameDirector.hp = 0;
            }
        }
    }

    private void Init()
    {
        Array.Clear(randomRecipe, 0, randomRecipe.Length); // initialize randomRecipe
    }

    private int CreateRandomRecipe() // create random recipe and return index of recipe
    {
        int randomIndex = Random.Range(0, 7);

        switch (randomIndex)
        {
            case 0:
                Array.Copy(recipe1, randomRecipe, ingredientAmt); // copy recipe1 to randomRecipe
                break;
            case 1:
                Array.Copy(recipe2, randomRecipe, ingredientAmt); // copy recipe2 to randomRecipe
                break;
            case 2:
                Array.Copy(recipe3, randomRecipe, ingredientAmt); // copy recipe3 to randomRecipe
                break;
        }

        return randomIndex;
    }

    public static Dictionary<int, int> ShowLeftoverRecipe() // return leftover recipe
    {
<<<<<<< HEAD
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
=======
        Dictionary<int, int> temp = new Dictionary<int, int>();
        for (int i = 0; i < randomRecipe.Length; i++) // copy randomRecipe to temp
        {
            if (randomRecipe[i] > 0) // if randomRecipe[i] is not 0, add to temp
            {
                temp.Add(i, randomRecipe[i]);
>>>>>>> 037113a09a7e88abd2eaff2a99f17905796a941d
            }
        }
        return temp;
    }

    public static void DecreaseIngredient(string name) // decrease ingredient
    {
        if (Enum.TryParse<Ingredients>(name, out var ingredient)) // if name is valid, decrease ingredient
        {
            randomRecipe[(int)ingredient]--;
        }
        else
        {
            throw new ArgumentException("Invalid ingredient name"); // if name is invalid, throw exception
        }
    }
}
