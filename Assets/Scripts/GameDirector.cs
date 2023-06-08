using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [SerializeField] public Slider hpBar;
    [SerializeField] public int maxHp = 10;
    [SerializeField] public GameObject Score_Panel = null;

    static public int hp;
    // Start is called before the first frame update
    void Start()
    {
        Score_Panel.SetActive(false);
        hp = maxHp;
        hpBar.value = (float)hp / (float)maxHp;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        HandleHp();

        if (hp <= 0)
        {
            Invoke("ActivateScorePanel", 3f);
        }
    }

    public void HandleHp()
    {
        hpBar.value = (float)hp / maxHp;
    }

    public void ActivateScorePanel()
    {
        Score_Panel.SetActive(true);
    }

    public void changeScene1()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void changeScene2()
    {
        SceneManager.LoadScene("FinishScene");
    }

    public void changeScene3()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
