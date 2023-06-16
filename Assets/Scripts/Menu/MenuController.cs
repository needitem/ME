using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject Panel_menu = null;
    // Start is called before the first frame update

    public void Click_Menu()
    {
        Time.timeScale = 0;
        Panel_menu.SetActive(true);
    }

    public void Click_Continue()
    {
        Time.timeScale = 1;
        Panel_menu.SetActive(false);
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
        Panel_menu.SetActive(false);
    }
}
