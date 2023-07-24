using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneDirector : MonoBehaviour
{
<<<<<<< HEAD
    public Image FadePanel;                 // 판넬 오브젝트
    public Text ScoreText;                  // 점수를 표시하는 텍스트 UI
    public float time = 0f;    
    public float F_time = 1.5f;


    IEnumerator FadeIn()
    {
        time = 0f;
        Color alpha = FadePanel.color;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            FadePanel.color = alpha;
            yield return null;
        }
    }

    // 페이드아웃 효과와 함께 다른 씬으로 전환하는 함수
    public IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        time = 0f;
        Color alpha = FadePanel.color;
        while (alpha.a < 1f)
        {   
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            FadePanel.color = alpha;
            yield return null;
        }

        // 씬 전환
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeScene1()
    {
        Recipe.Score = 0;                                               // Recipe 스크립트의 점수를 초기화합니다.
        StartCoroutine(FadeOutAndLoadScene("GameScene"));               // 페이드 효과와 함께 "GameScene"으로 씬을 전환합니다.
=======
    public Text ScoreText;  // �젏�닔瑜� �몴�떆�븯�뒗 �뀓�뒪�듃 UI

    public void ChangeScene1()
    {
        Recipe.Score = 0;                       // Recipe �뒪�겕由쏀듃�쓽 �젏�닔瑜� 珥덇린�솕�빀�땲�떎.
        SceneManager.LoadScene("GameScene");    // "GameScene"�쑝濡� �뵮�쓣 �쟾�솚�빀�땲�떎.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    public static void ChangeScene2()
    {
<<<<<<< HEAD
        SceneManager.LoadScene("FinishScene");          // "FinishScene"으로 씬을 전환합니다.
=======
        SceneManager.LoadScene("FinishScene");  // "FinishScene"�쑝濡� �뵮�쓣 �쟾�솚�빀�땲�떎.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    public void ChangeScene3()
    {
<<<<<<< HEAD
        Recipe.Score = 0;                                            // Recipe 스크립트의 점수를 초기화합니다.
        StartCoroutine(FadeOutAndLoadScene("TitleScene"));           // 페이드 효과와 함께 "TitleScene"으로 씬을 전환합니다.
=======
        Recipe.Score = 0;                       // Recipe �뒪�겕由쏀듃�쓽 �젏�닔瑜� 珥덇린�솕�빀�땲�떎.
        SceneManager.LoadScene("TitleScene");   // "TitleScene"�쑝濡� �뵮�쓣 �쟾�솚�빀�땲�떎.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    void Start()
    {
<<<<<<< HEAD
        ScoreText.text = "SCORE: " + Recipe.Score.ToString();  // 시작할 때 점수 텍스트를 업데이트합니다.
        StartCoroutine(FadeIn());
=======
        ScoreText.text = "SCORE: " + Recipe.Score.ToString();  // �떆�옉�븷 �븣 �젏�닔 �뀓�뒪�듃瑜� �뾽�뜲�씠�듃�빀�땲�떎.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    void Update()
    {
    }
}