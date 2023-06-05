using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject Menu_Panel = null;
    // Start is called before the first frame update

    public void Click_Menu()
    {
        Time.timeScale = 0;
        Menu_Panel.SetActive(true);
    }

    public void Click_Continue()
    {
        Time.timeScale = 1;
        Menu_Panel.SetActive(false);
    }

    public void Click_Exit()
    {
        Scenechange();
    }

    private void Scenechange()
    {
        SceneManager.LoadScene("TitleScene");
    }

    void Start()
    {
        Menu_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
