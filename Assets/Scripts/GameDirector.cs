using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class GameDirector : MonoBehaviour
{
    [SerializeField] public int maxHp = 5;
    [SerializeField] public Image[] heartImages;
    [SerializeField] public GameObject Gameover_Panel;
    [SerializeField] GameObject[] gIngredient_cnt;

    public Recipe recipe;
    public Image recipeImage;
    public Image[] ingredientImages;

    public Sprite[] recipeSprites;
    public Sprite[] ingredientSprites;


    static public int hp;

    // Start is called before the first frame update

    void Start()
    {
        hp = maxHp;
        Time.timeScale = 1;
        UpdateRecipeCnt();
        UpdateRecipeUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHearthp();
        UpdateRecipeCnt();
        UpdateRecipeUI();
        if (hp <= 0)
        {
            Invoke("ActivateGameover", 3f);
            Invoke("ChangeScene2", 5f);
        }
    }

    public void UpdateRecipeCnt()
    {
        for (int i = 0; i < 4; i++)
        {   
            try{
                gIngredient_cnt[i].GetComponent<Text>().text = "x" + Recipe.ShowLeftoverRecipe().Values.ToList()[i];
            }
            catch
            {
                gIngredient_cnt[i].GetComponent<Text>().text = "";
            }
       }
    }
    public void UpdateRecipeUI()
    {
        for (int i = 0; i < 4; i++)
        {
            try
            {
                ingredientImages[i].enabled = true;
                ingredientImages[i].sprite = ingredientSprites[Recipe.ShowLeftoverRecipe().Keys.ToList()[i]];
            }
            catch
            {
                ingredientImages[i].enabled = false;
            }
        }
    } 

    void VolumeChanged()
    {
        if (Gameover_Panel.activeSelf == true)
        {

        } 
    }

    private void UpdateHearthp()
    {
        for (int i = 0; i < maxHp; i++)
        {
            if (i < hp)
            {
                heartImages[i].enabled = true;
            }
            else
            {
                heartImages[i].enabled = false;
            }
        }
    }
    public void ActivateGameover()
    {
        Gameover_Panel.SetActive(true);
    }
    public void ChangeScene1()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ChangeScene2()
    {
        SceneManager.LoadScene("FinishScene");
    }
    public void ChangeScene3()
    {
        SceneManager.LoadScene("TitleScene");
    }
}