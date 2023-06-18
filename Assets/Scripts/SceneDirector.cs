using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneDirector : MonoBehaviour
{
    public Text ScoreText;
    // Start is called before the first frame update

    public void ChangeScene1()
    {
        Recipe.Score = 0;
        SceneManager.LoadScene("GameScene");
    }

    public static void ChangeScene2()
    {
        SceneManager.LoadScene("FinishScene");
    }

    public void ChangeScene3()
    {
        Recipe.Score = 0;
        SceneManager.LoadScene("TitleScene");
    }


    void Start()
    {
        ScoreText.text = "SCORE: " + Recipe.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
