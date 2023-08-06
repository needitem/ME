using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneDirector : MonoBehaviour
{
    public Text ScoreText;  // 점수를 표시하는 텍스트 UI
    public SceneFader sceneFader; // SceneFader 스크립트에 대한 참조

    public static void ChangeScene1()
    {
        Recipe.Score = 0;                       // Recipe 스크립트의 점수를 초기화합니다.
        StartCoroutine(ChangeSceneWithFade("GameScene"));
    }

    public void ChangeScene2()
    {
        StartCoroutine(ChangeSceneWithFade("FinishScene"));
    }

    public static void ChangeScene3()
    {
        Recipe.Score = 0;                       // Recipe 스크립트의 점수를 초기화합니다.
        StartCoroutine(ChangeSceneWithFade("TitleScene"));   // "TitleScene"으로 씬을 전환합니다.
    }

    private IEnumerator ChangeSceneWithFade(string sceneName)
    {
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(sceneName);
    }

    // 페이드 아웃 효과를 위한 코루틴
    private IEnumerator FadeOut()
    {
        sceneFader.StartFadeOut("GameScene");
        yield return new WaitForSeconds(sceneFader.fadeDuration);
    }


    public void ChangeScene4()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CutScene");  // "CutScene"으로 씬을 전환합니다.
    }
    void Start()
    {
        ScoreText.text = "SCORE: " + Recipe.Score.ToString();  // 시작할 때 점수 텍스트를 업데이트합니다.
    }

    void Update()
    {
    }
}