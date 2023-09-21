using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneDirector : MonoBehaviour
{
    public Text ScoreText;  // 점수를 표시하는 텍스트 UI
    public Text BestScoreText;
    private string KeyName = "BestScore";
    private int bestScore = 0;

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

    public void ChangeScene_Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }


    public void ChangeScene4()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CutScene");  // "CutScene"으로 씬을 전환합니다.
    }
    void Start()
    {
        if (Recipe.score > bestScore)
        {
            PlayerPrefs.SetInt(KeyName, Recipe.score);
        }
        bestScore = PlayerPrefs.GetInt(KeyName, 0);

        ScoreText.text = "SCORE: " + Recipe.score.ToString();  // 시작할 때 점수 텍스트를 업데이트합니다.
        BestScoreText.text = $"Best Score: {bestScore.ToString()}";
    }

    public void OnClick_Quitbtn()
    {
        Application.Quit();
    }
}