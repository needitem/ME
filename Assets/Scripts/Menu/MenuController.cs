using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject Panel_menu = null;
    public GameObject Toggle1 = null;
    public GameObject Toggle2 = null;
    public Image[] OnImage;
    public Image[] OffImage;
    // Start is called before the first frame update

    private bool isMuted1 = false;
    private bool isMuted2 = false;

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
        UpdateMuteImages();
    }

    public void ToggleMute1()
    {
        isMuted1 = !isMuted1;
        UpdateMuteImages();
    }

    public void ToggleMute2()
    {
        isMuted2 = !isMuted2;
        UpdateMuteImages();
    }

    private void UpdateMuteImages()
    {
        OnImage[0].gameObject.SetActive(!isMuted1);
        OffImage[0].gameObject.SetActive(isMuted1);
        OnImage[1].gameObject.SetActive(!isMuted2);
        OffImage[1].gameObject.SetActive(isMuted2);
    }
}
