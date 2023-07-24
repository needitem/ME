using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

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
    private readonly int[] recipe1 = { 2, 0, 0, 0, 0, 2, 3 };
    private readonly int[] recipe2 = { 0, 3, 0, 1, 3, 2, 0 };
    private readonly int[] recipe3 = { 0, 0, 2, 2, 0, 3, 0 };
    public static readonly int[] randomRecipe = new int[ingredientAmt];

    public static int RecipeIndex { get; private set; }

    public static int Score;

    public bool IsRecipeComplete(int[] randomRecipe) //레시피가 완성되었는지 확인, 완성되었으면 true, 아니면 false
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

    public bool IsRecipeWrong(int[] randomRecipe) //레시피가 틀렸는지 확인, 틀렸으면 true, 아니면 false
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
        Init();
        gameDirector = GameObject.Find("GameDirector");
        RecipeIndex = CreateRandomRecipe();
    }

    private void Update()
    {
       if (IsRecipeComplete(randomRecipe) || IsRecipeWrong(randomRecipe)) //만약 레시피가 완성되었거나 틀렸다면 레시피를 새로 만들고 UI를 업데이트
        {
            gameDirector.GetComponent<GameDirector>().UpdateRecipeUI(); // update recipe UI
            if (IsRecipeComplete(randomRecipe))
            {
                Score += 300; // 레시피가 완성되었으면 점수 300점 추가
            }
            else if (IsRecipeWrong(randomRecipe))
            {
                Init();
                GameDirector.hp = 0; // 레시피가 틀렸으면 사망
            }
            Init();
            RecipeIndex = CreateRandomRecipe(); //새로운 레시피 생성
        }
    }

    private void Init()
    {
        Array.Clear(randomRecipe, 0, randomRecipe.Length); //랜덤레시피 초기화
    }

    private int CreateRandomRecipe() //랜덤레시피 생성
    {
        int randomIndex = Random.Range(0, 3);

        switch (randomIndex)
        {
            case 0:
                Array.Copy(recipe1, randomRecipe, ingredientAmt); //레시피1을 randomRecipe에 복사
                break;
            case 1:
                Array.Copy(recipe2, randomRecipe, ingredientAmt); //레시피2를 randomRecipe에 복사
                break;
            case 2:
                Array.Copy(recipe3, randomRecipe, ingredientAmt); //레시피3을 randomRecipe에 복사
                break;
        }
        return randomIndex;
    }

    public static Dictionary<int, int> ShowLeftoverRecipe() //잔여 레시피를 보여줌
    {
        Dictionary<int, int> temp = new Dictionary<int, int>();
        for (int i = 0; i < randomRecipe.Length; i++) //모든 재료에 대해서
        {
            if (randomRecipe[i] > 0) //재료가 남아있으면
            {
                temp.Add(i, randomRecipe[i]); //temp에 추가
            }
        }
        return temp;
    }

    public static void DecreaseIngredient(string name) //재료를 하나 감소시킴
    {
        if (Enum.TryParse<Ingredients>(name, out var ingredient)) //만약 재료 이름이 유효하면
        {
            randomRecipe[(int)ingredient]--;
        }
        else
        {
            throw new ArgumentException("Invalid ingredient name"); //유효하지 않은 재료 이름이면 예외처리
        }
    }
}