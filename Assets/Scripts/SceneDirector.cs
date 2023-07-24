using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneDirector : MonoBehaviour
{
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
    }

    public static void ChangeScene2()
    {
        SceneManager.LoadScene("FinishScene");          // "FinishScene"으로 씬을 전환합니다.
    }

    public void ChangeScene3()
    {
        Recipe.Score = 0;                                            // Recipe 스크립트의 점수를 초기화합니다.
        StartCoroutine(FadeOutAndLoadScene("TitleScene"));           // 페이드 효과와 함께 "TitleScene"으로 씬을 전환합니다.
    }


    void Start()
    {
        ScoreText.text = "SCORE: " + Recipe.Score.ToString();  // 시작할 때 점수 텍스트를 업데이트합니다.
        StartCoroutine(FadeIn());
    }

    void Update()
    {
    }
}