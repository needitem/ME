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
    carrot
}

public class Recipe : MonoBehaviour
{
    [SerializeField] private GameObject gameDirector;
    private const int ingredientAmt = 7;
    private readonly int[] recipe1 = { 20, 0, 0, 0, 0, 10, 10 };
    private readonly int[] recipe2 = { 0, 10, 0, 10, 10, 10, 0 };
    private readonly int[] recipe3 = { 0, 0, 10, 10, 0, 10, 0 };
    private static readonly int[] randomRecipe = new int[ingredientAmt];

    public static int RecipeIndex { get; private set; }

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

    private void Awake()
    {
        Init();
        gameDirector = GameObject.Find("GameDirector");
        RecipeIndex = CreateRandomRecipe();
    }

    private void Update()
    {
        if (IsRecipeComplete(randomRecipe) || IsRecipeWrong(randomRecipe))
        {
            Init();
            RecipeIndex = CreateRandomRecipe();
            gameDirector.GetComponent<GameDirector>().UpdateRecipeUI();
            if (IsRecipeComplete(randomRecipe))
            {
                //RecipeIndex = CreateRandomRecipe();
            }
            else if (IsRecipeWrong(randomRecipe))
            {
               //GameDirector.hp = 0;
            }
        }
    }

    private void Init()
    {
        Array.Clear(randomRecipe, 0, randomRecipe.Length);
    }

    private int CreateRandomRecipe()
    {
        int randomIndex = Random.Range(0, 3);

        switch (randomIndex)
        {
            case 0:
                Array.Copy(recipe1, randomRecipe, ingredientAmt);
                break;
            case 1:
                Array.Copy(recipe2, randomRecipe, ingredientAmt);
                break;
            case 2:
                Array.Copy(recipe3, randomRecipe, ingredientAmt);
                break;
        }

        return randomIndex;
    }

    public static Dictionary<int, int> ShowLeftoverRecipe()
    {
        Dictionary<int, int> temp = new Dictionary<int, int>();
        for (int i = 0; i < randomRecipe.Length; i++)
        {
            if (randomRecipe[i] > 0)
            {
                temp.Add(i, randomRecipe[i]);
            }
        }

        return temp;
    }

    public static void DecreaseIngredient(string name)
    {
        if (Enum.TryParse<Ingredients>(name, out var ingredient))
        {
            randomRecipe[(int)ingredient]--;
        }
        else
        {
            throw new ArgumentException("Invalid ingredient name");
        }
    }
}
