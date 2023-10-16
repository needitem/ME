using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class GameDirector : MonoBehaviour
{
    public static bool isTouch = false;// 튜토리얼에서 터치를 했는가 알려주는 스위치변수
    [SerializeField] public int maxHp = 3;              // 플레이어의 최대 HP
    [SerializeField] public Image[] heartImages;        // 플레이어의 HP를 나타내는 하트 이미지 배열
    [SerializeField] GameObject[] gIngredient_cnt;      // 재료 개수 텍스트를 나타내는 게임 오브젝트 배열
    [SerializeField] public GameObject Gameover_Panel;  // 게임 오버 패널 오브젝트
    [SerializeField] public GameObject ScoreText;
    [SerializeField] public GameObject effectUI;
    [SerializeField] public GameObject recipeObj;
    

    public Recipe recipe;                   // 레시피 스크립트 참조
    public Image recipeImage;               // 레시피 이미지 컴포넌트
    public Image[] ingredientImages;        // 재료 이미지 컴포넌트 배열
    public Image EffectRecipe;
    
    public Image nextRecipeImage;               // 다음 레시피 이미지 컴포넌트
    public Image[] nextIngredientImages;        // 다음 재료 이미지 컴포넌트 배열

    public Sprite[] recipeSprites;          // 레시피 스프라이트 배열
    public Sprite[] ingredientSprites;      // 재료 스프라이트 배열

    static public int hp;   // 플레이어의 현재 hp(static)

    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        recipeObj = GameObject.Find("Canvas/Recipe");
        Application.targetFrameRate = 60;       //모바일 환경일 경우 프레임을 60으로 고정
        QualitySettings.vSyncCount = 0;

        hp = maxHp;                             // HP를 최대 값(3)으로 설정
        Time.timeScale = 1;                     // 시간 스케일을 1로 설정 (일반 속도)
                                                // Time.timeScale 메서드를 사용하여 시간스케일을 1로 선언(시간 흐름을 정상 속도로)
                                                // Time.timeScale = 0(시간 흐름을 멈춤)
        UpdateRecipeCnt();                      // UI에서 재료 개수 업데이트
        UpdateRecipeUI();                       // UI에서 레시피와 재료 이미지 업데이트
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        effectUI.GetComponent<EffectUI>().SpringRecipe(recipeObj, time);

        ScoreText.GetComponent<Text>().text = "SCORE: " + Recipe.score;
        UpdateHearthp();        // UI에서 플레이어의 HP를 나타내는 하트 이미지 업데이트
        UpdateRecipeCnt();      // UI에서 재료 개수 업데이트
        UpdateRecipeUI();       // UI에서 레시피와 재료 이미지 업데이트
        UpdateNextRecipe();

        if (hp <= 0)            // hp가 0이라면 
        {
            Invoke("ActivateGameover", 3f);     // 3초 후 게임 오버 패널을 활성화
            Invoke("GameOverChange", 5f);       // 5초 후 게임 오버 씬으로 전환                                               
                                                // Invoke("특정함수", "xf") 
        }                                       // 특정 함수를 x초 후에 불러오게 한다.
    }
    public void UpdateNextRecipe()
    {
        for (int i = 0; i < nextIngredientImages.Length; i++)
        {
            try
            {
                nextIngredientImages[i].enabled = true;
                nextRecipeImage.sprite = recipeSprites[Recipe.nextRecipeIndex];
                nextIngredientImages[i].sprite = ingredientSprites[Recipe.ShowNextRecipe().ToList()[i]];
            }
            catch
            {
                nextIngredientImages[i].enabled = false;
            }
        }
    }

    public void UpdateRecipeCnt()
    {
        for (int i = 0; i < 4; i++)     // 0부터 3까지의 인덱스를 사용하여 반복
        {
            try
            {
                // 잔여 레시피 개수를 가져와서 UI에 업데이트
                // Recipe.ShowLeftoverRecipe().Values.ToList()[i]를 사용하여 잔여 레시피 개수를 가져온다.
                // gIngredient_cnt[i].GetComponent<Text>().text를 사용하여
                // gIngredient_cnt 배열에서 현재 인덱스에 해당하는 GameObject의 Text 컴포넌트를 가져온다.
                gIngredient_cnt[i].GetComponent<Text>().text = "x" + Recipe.ShowLeftoverRecipe().Values.ToList()[i];
            }
            catch
            {
                // 만약 예외가 발생한다면(개수가 없을 경우), 해당 인덱스에 해당하는 Text 컴포넌트의 text 속성을 비워둔다.
                gIngredient_cnt[i].GetComponent<Text>().text = "";
            }
        }
    }

    public void UpdateRecipeUI()
    {
        for (int i = 0; i < 4; i++)     // 0부터 3까지의 인덱스를 사용하여 반복
        {
            try
            {
                // ingredientImages[i].enabled = true;를 사용하여 ingredientImages 배열에서
                // 현재 인덱스에 해당하는 Image 컴포넌트의 활성화 상태를 true로 설정
                // enabled는 Unity의 컴포넌트나 게임 오브젝트의 활성화 여부를 나타내는 속성
                ingredientImages[i].enabled = true;

                // recipeSprites 배열에서 레시피스크립트의 레시피 인덱스 값에 해당하는 스프라이트로 설정
                recipeImage.sprite = recipeSprites[Recipe.recipeIndex];
                EffectRecipe.sprite = recipeSprites[Recipe.recipeIndex];
                // 재료 이미지 배열에서 잔여 레시피의 키(재료)를 가져온 후 키에 해당하는 재료 이미지 스프라이트 적용
                ingredientImages[i].sprite = ingredientSprites[Recipe.ShowLeftoverRecipe().Keys.ToList()[i]];
            }
            catch
            {
                //만약 예외가 발생한다면 ingredientImages 배열에서 현재 인덱스에 해당하는 Image 컴포넌트의 활성화 상태를 false로 설정
                ingredientImages[i].enabled = false;
            }
        }
    }

    private void UpdateHearthp()
    {
        for (int i = 0; i < maxHp; i++)             //0부터 maxHp(3)까지의 인덱스를 사용하여 반복
        {
            if (i < hp)                             // hp가 i보다 작을 경우
            {
                heartImages[i].enabled = true;      // enabled = true를 사용하여 hp이미지 배열을 UI로 나타낸다.
            }
            else
            {
                heartImages[i].enabled = false;     // 그게 아니라면 hp 이미지 배열 UI를 비활성화 시킴
            }
        }
    }

    public void ActivateGameover()
    {
        Gameover_Panel.SetActive(true);             // SetActive메서드를 활용하여 해당 Gameover판넬 오브젝트를 true(활성화) 시킨다.
    }

    public void GameOverChange()
    {
        SceneDirector.ChangeScene2();               // 게임오버 시 씬 디렉터의 ChangeScene2함수를 실행한다(finishScene 전환)
    }


}