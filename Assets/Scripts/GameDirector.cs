using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class GameDirector : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] public int maxHp = 3;              // 플레이어의 최대 HP
    [SerializeField] public Image[] heartImages;        // 플레이어의 HP를 나타내는 하트 이미지 배열
    [SerializeField] GameObject[] gIngredient_cnt;      // 재료 개수 텍스트를 나타내는 게임 오브젝트 배열
    [SerializeField] public GameObject Gameover_Panel;  // 게임 오버 패널 오브젝트

    public Recipe recipe;                   // 레시피 스크립트 참조
    public Image recipeImage;               // 레시피 이미지 컴포넌트
    public Image[] ingredientImages;        // 재료 이미지 컴포넌트 배열

    public Sprite[] recipeSprites;          // 레시피 스프라이트 배열
    public Sprite[] ingredientSprites;      // 재료 스프라이트 배열


    static public int hp;   // 플레이어의 현재 hp(static)
=======
    [SerializeField] public int maxHp = 3;              // �뵆�젅�씠�뼱�쓽 理쒕�� HP
    [SerializeField] public Image[] heartImages;        // �뵆�젅�씠�뼱�쓽 HP瑜� �굹����궡�뒗 �븯�듃 �씠誘몄�� 諛곗뿴
    [SerializeField] GameObject[] gIngredient_cnt;      // �옱猷� 媛쒖닔 �뀓�뒪�듃瑜� �굹����궡�뒗 寃뚯엫 �삤釉뚯젥�듃 諛곗뿴
    [SerializeField] public GameObject Gameover_Panel;  // 寃뚯엫 �삤踰� �뙣�꼸 �삤釉뚯젥�듃

    public Recipe recipe;                   // �젅�떆�뵾 �뒪�겕由쏀듃 李몄“
    public Image recipeImage;               // �젅�떆�뵾 �씠誘몄�� 而댄룷�꼳�듃
    public Image[] ingredientImages;        // �옱猷� �씠誘몄�� 而댄룷�꼳�듃 諛곗뿴

    public Sprite[] recipeSprites;          // �젅�떆�뵾 �뒪�봽�씪�씠�듃 諛곗뿴
    public Sprite[] ingredientSprites;      // �옱猷� �뒪�봽�씪�씠�듃 諛곗뿴


    static public int hp;   // �뵆�젅�씠�뼱�쓽 �쁽�옱 hp(static)
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d


    // Start is called before the first frame update


    void Start()
    {
<<<<<<< HEAD
        Application.targetFrameRate = 60;       //모바일 환경일 경우 프레임을 60으로 고정
        QualitySettings.vSyncCount = 0;

        hp = maxHp;                             // HP를 최대 값(3)으로 설정
        Time.timeScale = 1;                     // 시간 스케일을 1로 설정 (일반 속도)
                                                // Time.timeScale 메서드를 사용하여 시간스케일을 1로 선언(시간 흐름을 정상 속도로)
                                                // Time.timeScale = 0(시간 흐름을 멈춤)
        UpdateRecipeCnt();                      // UI에서 재료 개수 업데이트
        UpdateRecipeUI();                       // UI에서 레시피와 재료 이미지 업데이트
=======
        Application.targetFrameRate = 60;       //紐⑤컮�씪 �솚寃쎌씪 寃쎌슦 �봽�젅�엫�쓣 60�쑝濡� 怨좎젙
        QualitySettings.vSyncCount = 0;

        hp = maxHp;                             // HP瑜� 理쒕�� 媛�(3)�쑝濡� �꽕�젙
        Time.timeScale = 1;                     // �떆媛� �뒪耳��씪�쓣 1濡� �꽕�젙 (�씪諛� �냽�룄)
                                                // Time.timeScale 硫붿꽌�뱶瑜� �궗�슜�븯�뿬 �떆媛꾩뒪耳��씪�쓣 1濡� �꽑�뼵(�떆媛� �쓲由꾩쓣 �젙�긽 �냽�룄濡�)
                                                // Time.timeScale = 0(�떆媛� �쓲由꾩쓣 硫덉땄)
        UpdateRecipeCnt();                      // UI�뿉�꽌 �옱猷� 媛쒖닔 �뾽�뜲�씠�듃
        UpdateRecipeUI();                       // UI�뿉�꽌 �젅�떆�뵾��� �옱猷� �씠誘몄�� �뾽�뜲�씠�듃
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        UpdateHearthp();        // UI에서 플레이어의 HP를 나타내는 하트 이미지 업데이트
        UpdateRecipeCnt();      // UI에서 재료 개수 업데이트
        UpdateRecipeUI();       // UI에서 레시피와 재료 이미지 업데이트

        if (hp <= 0)            // hp가 0이라면
        {
            Invoke("ActivateGameover", 3f);     // 3초 후 게임 오버 패널을 활성화
            Invoke("GameOverChange", 5f);       // 5초 후 게임 오버 씬으로 전환                                               
                                                // Invoke("특정함수", "xf") 
        }                                       // 특정 함수를 x초 후에 불러오게 한다.
=======
        UpdateHearthp();        // UI�뿉�꽌 �뵆�젅�씠�뼱�쓽 HP瑜� �굹����궡�뒗 �븯�듃 �씠誘몄�� �뾽�뜲�씠�듃
        UpdateRecipeCnt();      // UI�뿉�꽌 �옱猷� 媛쒖닔 �뾽�뜲�씠�듃
        UpdateRecipeUI();       // UI�뿉�꽌 �젅�떆�뵾��� �옱猷� �씠誘몄�� �뾽�뜲�씠�듃

        if (hp <= 0)            // hp媛� 0�씠�씪硫�
        {
            Invoke("ActivateGameover", 3f);     // 3珥� �썑 寃뚯엫 �삤踰� �뙣�꼸�쓣 �솢�꽦�솕
            Invoke("GameOverChange", 5f);       // 5珥� �썑 寃뚯엫 �삤踰� �뵮�쑝濡� �쟾�솚                                               
                                                // Invoke("�듅�젙�븿�닔", "xf") 
        }                                       // �듅�젙 �븿�닔瑜� x珥� �썑�뿉 遺덈윭�삤寃� �븳�떎.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    public void UpdateRecipeCnt()
    {
<<<<<<< HEAD
        for (int i = 0; i < 4; i++)     // 0부터 3까지의 인덱스를 사용하여 반복
        {   
            try{
                // 잔여 레시피 개수를 가져와서 UI에 업데이트
                // Recipe.ShowLeftoverRecipe().Values.ToList()[i]를 사용하여 잔여 레시피 개수를 가져온다.
                // gIngredient_cnt[i].GetComponent<Text>().text를 사용하여
                // gIngredient_cnt 배열에서 현재 인덱스에 해당하는 GameObject의 Text 컴포넌트를 가져온다.
=======
        for (int i = 0; i < 4; i++)     // 0遺��꽣 3源뚯���쓽 �씤�뜳�뒪瑜� �궗�슜�븯�뿬 諛섎났
        {   
            try{
                // �옍�뿬 �젅�떆�뵾 媛쒖닔瑜� 媛��졇����꽌 UI�뿉 �뾽�뜲�씠�듃
                // Recipe.ShowLeftoverRecipe().Values.ToList()[i]瑜� �궗�슜�븯�뿬 �옍�뿬 �젅�떆�뵾 媛쒖닔瑜� 媛��졇�삩�떎.
                // gIngredient_cnt[i].GetComponent<Text>().text瑜� �궗�슜�븯�뿬
                // gIngredient_cnt 諛곗뿴�뿉�꽌 �쁽�옱 �씤�뜳�뒪�뿉 �빐�떦�븯�뒗 GameObject�쓽 Text 而댄룷�꼳�듃瑜� 媛��졇�삩�떎.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
                gIngredient_cnt[i].GetComponent<Text>().text = "x" + Recipe.ShowLeftoverRecipe().Values.ToList()[i];
            }
            catch
            {
<<<<<<< HEAD
                // 만약 예외가 발생한다면(개수가 없을 경우), 해당 인덱스에 해당하는 Text 컴포넌트의 text 속성을 비워둔다.
=======
                // 留뚯빟 �삁�쇅媛� 諛쒖깮�븳�떎硫�(媛쒖닔媛� �뾾�쓣 寃쎌슦), �빐�떦 �씤�뜳�뒪�뿉 �빐�떦�븯�뒗 Text 而댄룷�꼳�듃�쓽 text �냽�꽦�쓣 鍮꾩썙�몦�떎.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
                gIngredient_cnt[i].GetComponent<Text>().text = "";
            }
       }
    }
    public void UpdateRecipeUI()
    {
<<<<<<< HEAD
        for (int i = 0; i < 4; i++)     // 0부터 3까지의 인덱스를 사용하여 반복
        {
            try
            {
                // ingredientImages[i].enabled = true;를 사용하여 ingredientImages 배열에서
                // 현재 인덱스에 해당하는 Image 컴포넌트의 활성화 상태를 true로 설정
                // enabled는 Unity의 컴포넌트나 게임 오브젝트의 활성화 여부를 나타내는 속성
                ingredientImages[i].enabled = true;

                // recipeSprites 배열에서 레시피스크립트의 레시피 인덱스 값에 해당하는 스프라이트로 설정
                recipeImage.sprite = recipeSprites[Recipe.RecipeIndex];

                // 재료 이미지 배열에서 잔여 레시피의 키(재료)를 가져온 후 키에 해당하는 재료 이미지 스프라이트 적용
=======
        for (int i = 0; i < 4; i++)     // 0遺��꽣 3源뚯���쓽 �씤�뜳�뒪瑜� �궗�슜�븯�뿬 諛섎났
        {
            try
            {
                // ingredientImages[i].enabled = true;瑜� �궗�슜�븯�뿬 ingredientImages 諛곗뿴�뿉�꽌
                // �쁽�옱 �씤�뜳�뒪�뿉 �빐�떦�븯�뒗 Image 而댄룷�꼳�듃�쓽 �솢�꽦�솕 �긽�깭瑜� true濡� �꽕�젙
                // enabled�뒗 Unity�쓽 而댄룷�꼳�듃�굹 寃뚯엫 �삤釉뚯젥�듃�쓽 �솢�꽦�솕 �뿬遺�瑜� �굹����궡�뒗 �냽�꽦
                ingredientImages[i].enabled = true;

                // recipeSprites 諛곗뿴�뿉�꽌 �젅�떆�뵾�뒪�겕由쏀듃�쓽 �젅�떆�뵾 �씤�뜳�뒪 媛믪뿉 �빐�떦�븯�뒗 �뒪�봽�씪�씠�듃濡� �꽕�젙
                recipeImage.sprite = recipeSprites[Recipe.RecipeIndex];

                // �옱猷� �씠誘몄�� 諛곗뿴�뿉�꽌 �옍�뿬 �젅�떆�뵾�쓽 �궎(�옱猷�)瑜� 媛��졇�삩 �썑 �궎�뿉 �빐�떦�븯�뒗 �옱猷� �씠誘몄�� �뒪�봽�씪�씠�듃 �쟻�슜
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
                ingredientImages[i].sprite = ingredientSprites[Recipe.ShowLeftoverRecipe().Keys.ToList()[i]];
            }
            catch
            {
<<<<<<< HEAD
                //만약 예외가 발생한다면 ingredientImages 배열에서 현재 인덱스에 해당하는 Image 컴포넌트의 활성화 상태를 false로 설정
=======
                //留뚯빟 �삁�쇅媛� 諛쒖깮�븳�떎硫� ingredientImages 諛곗뿴�뿉�꽌 �쁽�옱 �씤�뜳�뒪�뿉 �빐�떦�븯�뒗 Image 而댄룷�꼳�듃�쓽 �솢�꽦�솕 �긽�깭瑜� false濡� �꽕�젙
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
                ingredientImages[i].enabled = false;
            }
        }
    } 

    private void UpdateHearthp()
    {
<<<<<<< HEAD
        for (int i = 0; i < maxHp; i++)             //0부터 maxHp(3)까지의 인덱스를 사용하여 반복
        {
            if (i < hp)                             // hp가 i보다 작을 경우
            {
                heartImages[i].enabled = true;      // enabled = true를 사용하여 hp이미지 배열을 UI로 나타낸다.
            }
            else
            {
                heartImages[i].enabled = false;     // 그게 아니라면 hp 이미지 배열 UI를 비활성화 시킴
=======
        for (int i = 0; i < maxHp; i++)             //0遺��꽣 maxHp(3)源뚯���쓽 �씤�뜳�뒪瑜� �궗�슜�븯�뿬 諛섎났
        {
            if (i < hp)                             // hp媛� i蹂대떎 �옉�쓣 寃쎌슦
            {
                heartImages[i].enabled = true;      // enabled = true瑜� �궗�슜�븯�뿬 hp�씠誘몄�� 諛곗뿴�쓣 UI濡� �굹����궦�떎.
            }
            else
            {
                heartImages[i].enabled = false;     // 洹멸쾶 �븘�땲�씪硫� hp �씠誘몄�� 諛곗뿴 UI瑜� 鍮꾪솢�꽦�솕 �떆�궡
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
            }
        }
    }

    public void ActivateGameover()
    {
<<<<<<< HEAD
        Gameover_Panel.SetActive(true);             // SetActive메서드를 활용하여 해당 Gameover판넬 오브젝트를 true(활성화) 시킨다.
=======
        Gameover_Panel.SetActive(true);             // SetActive硫붿꽌�뱶瑜� �솢�슜�븯�뿬 �빐�떦 Gameover�뙋�꽟 �삤釉뚯젥�듃瑜� true(�솢�꽦�솕) �떆�궓�떎.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    public void GameOverChange()
    {
<<<<<<< HEAD
        SceneDirector.ChangeScene2();               // 게임오버 시 씬 디렉터의 ChangeScene2함수를 실행한다(finishScene 전환)
=======
        SceneDirector.ChangeScene2();               // 寃뚯엫�삤踰� �떆 �뵮 �뵒�젆�꽣�쓽 ChangeScene2�븿�닔瑜� �떎�뻾�븳�떎(finishScene �쟾�솚)
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }
} 