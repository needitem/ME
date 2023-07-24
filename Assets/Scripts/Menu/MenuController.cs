using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject Panel_menu = null;                // 메뉴 패널을 나타내는 게임 오브젝트
    public GameObject Toggle1 = null;                   // SFX 토글을 나타내는 게임 오브젝트
    public GameObject Toggle2 = null;                   // BGM 토글을 나타내는 게임 오브젝트
    public Image[] OnImage;                             // 활성화 이미지 배열
    public Image[] OffImage;                            // 비활성화 이미지 배열

    private bool[] isMuted = new bool[2]; // SFX와 BGM의 음소거 여부를 저장하는 배열

    public void Click_Menu()    // 메뉴 버튼을 클릭했을 경우
    {
        Time.timeScale = 0;                             // 게임 시간을 일시적으로 멈춥니다.
        Panel_menu.SetActive(true);                     // 메뉴 패널을 활성화합니다.
    }

    public void Click_Continue() // 메뉴패널의 CONTINUE 버튼 클릭했을 경우
    {
        Time.timeScale = 1;                             // 게임 시간을 다시 시작합니다.
        Panel_menu.SetActive(false);                    // 메뉴 패널을 비활성화합니다.
    }

    public void Click_Exit() // 메뉴패널의 QUIT 버튼 클릭했을 경우
    {
        ChangeScene3();
    }

    public void ChangeScene3()
    {
        SceneManager.LoadScene("TitleScene");
    }

    void Start()
    {
        Panel_menu.SetActive(false);
        isMuted[0] = false; // SFX 초기 음소거 상태 설정
        isMuted[1] = false; // BGM 초기 음소거 상태 설정
        UpdateMuteImages();
    }

    public void ToggleMute(int index) // SFX와 BGM 토글을 구분하는 인덱스를 받습니다.
    {
        isMuted[index] = !isMuted[index]; // 해당 토글의 음소거 상태를 반전시킵니다.
        UpdateMuteImages();
    }

    private void UpdateMuteImages()
    {
        // SFX와 BGM 토글의 활성화/비활성화 이미지를 설정합니다.
        for (int i = 0; i < 2; i++)
        {
            OnImage[i].gameObject.SetActive(!isMuted[i]);
            OffImage[i].gameObject.SetActive(isMuted[i]);
        }
    }
}