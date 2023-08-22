using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneDirector : MonoBehaviour
{
    public Text ScoreText;  // 점수를 표시하는 텍스트 UI

    public static void ChangeScene1()
    {
        Recipe.score = 0;                       // Recipe 스크립트의 점수를 초기화합니다.
        SceneManager.LoadScene("GameScene");    // "GameScene"으로 씬을 전환합니다.
    }

    public static void ChangeScene2()
    {
        SceneManager.LoadScene("FinishScene");  // "FinishScene"으로 씬을 전환합니다.
    } 

    public static void ChangeScene3()
    {
        Recipe.score = 0;                       // Recipe 스크립트의 점수를 초기화합니다.
        SceneManager.LoadScene("TitleScene");   // "TitleScene"으로 씬을 전환합니다.
    }


    public void ChangeScene4()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CutScene");  // "CutScene"으로 씬을 전환합니다.
    }
    void Start()
    {
        ScoreText.text = "SCORE: " + Recipe.score.ToString();  // 시작할 때 점수 텍스트를 업데이트합니다.
    }

    void Update()
    {
    }
}