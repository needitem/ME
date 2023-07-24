using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    public GameObject Panel_menu = null;                // 硫붾돱 �뙣�꼸�쓣 �굹����궡�뒗 寃뚯엫 �삤釉뚯젥�듃
    public GameObject Toggle1 = null;                   // SFX �넗湲��쓣 �굹����궡�뒗 寃뚯엫 �삤釉뚯젥�듃
    public GameObject Toggle2 = null;                   // BGM �넗湲��쓣 �굹����궡�뒗 寃뚯엫 �삤釉뚯젥�듃
    public Image[] OnImage;                             // �솢�꽦�솕 �씠誘몄�� 諛곗뿴
    public Image[] OffImage;                            // 鍮꾪솢�꽦�솕 �씠誘몄�� 諛곗뿴

    private bool isMuted1 = false;                      // SFX �넗湲��쓽 �쓬�냼嫄� �뿬遺�
    private bool isMuted2 = false;                      // BGM �넗湲��쓽 �쓬�냼嫄� �뿬遺�

    public void Click_Menu()    // 硫붾돱 踰꾪듉�쓣 �겢由��뻽�쓣 寃쎌슦
    {
        Time.timeScale = 0;                             // 寃뚯엫 �떆媛꾩쓣 �씪�떆�쟻�쑝濡� 硫덉땅�땲�떎.
        Panel_menu.SetActive(true);                     // 硫붾돱 �뙣�꼸�쓣 �솢�꽦�솕�빀�땲�떎.
    }

    public void Click_Continue() // 硫붾돱�뙣�꼸�쓽 CONTINUE 踰꾪듉 �겢由��뻽�쓣 寃쎌슦
    {
        Time.timeScale = 1;                             // 寃뚯엫 �떆媛꾩쓣 �떎�떆 �떆�옉�빀�땲�떎.
        Panel_menu.SetActive(false);                    // 硫붾돱 �뙣�꼸�쓣 鍮꾪솢�꽦�솕�빀�땲�떎.
    }

    public void Click_Exit() // 硫붾돱�뙣�꼸�쓽 QUIT 踰꾪듉 �겢由��뻽�쓣 寃쎌슦
    {
        Scenechange();                                  // Scenechange �븿�닔瑜� �샇異쒗븯�뿬 ����씠��� �뵮�쑝濡� �쟾�솚�빀�땲�떎.
    }

    private void Scenechange() // �뵮 �쟾�솚 �븿�닔
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    {
        SceneManager.LoadScene("TitleScene");           // "TitleScene"�쓣 濡쒕뱶�븯�뿬 �뵮�쓣 �쟾�솚�빀�땲�떎.
    }

    void Start()
    {
<<<<<<< HEAD
        Panel_menu.SetActive(false);
        isMuted[0] = false; // SFX 초기 음소거 상태 설정
        isMuted[1] = false; // BGM 초기 음소거 상태 설정
        UpdateMuteImages();
    }

    public void ToggleMute(int index) // SFX와 BGM 토글을 구분하는 인덱스를 받습니다.
    {
        isMuted[index] = !isMuted[index]; // 해당 토글의 음소거 상태를 반전시킵니다.
        UpdateMuteImages();
=======
        Panel_menu.SetActive(false);                    // 硫붾돱 �뙣�꼸�쓣 泥섏쓬�뿉�뒗 鍮꾪솢�꽦�솕�빀�땲�떎.
        UpdateMuteImages();                             // �쓬�냼嫄� �씠誘몄��瑜� �뾽�뜲�씠�듃�빀�땲�떎.
    }

    public void ToggleMute1() // SFX�넗湲��쓽 �쓬�냼嫄� �겢由��뻽�쓣寃쎌슦
    {
        isMuted1 = !isMuted1;                           // SFX �넗湲��쓽 �쓬�냼嫄� �씠誘몄��瑜� 諛섏쟾�떆�궢�땲�떎.
        UpdateMuteImages();                             // �쓬�냼嫄� �씠誘몄��瑜� �뾽�뜲�씠�듃�빀�땲�떎.
    }

    public void ToggleMute2() // BGM�넗湲��쓽 �쓬�냼嫄� �겢由��뻽�쓣寃쎌슦
    {
        isMuted2 = !isMuted2;                           // BGM �넗湲��쓽 �쓬�냼嫄� �씠誘몄��瑜� 諛섏쟾�떆�궢�땲�떎.
        UpdateMuteImages();                             // �쓬�냼嫄� �씠誘몄��瑜� �뾽�뜲�씠�듃�빀�땲�떎.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    private void UpdateMuteImages() // �쓬�냼嫄� �씠誘몄�� 蹂�寃� �븿�닔
    {
<<<<<<< HEAD
        // SFX와 BGM 토글의 활성화/비활성화 이미지를 설정합니다.
        for (int i = 0; i < 2; i++)
        {
            OnImage[i].gameObject.SetActive(!isMuted[i]);
            OffImage[i].gameObject.SetActive(isMuted[i]);
        }
=======
        OnImage[0].gameObject.SetActive(!isMuted1);     // SFX �넗湲��쓽 �솢�꽦�솕 �씠誘몄��瑜� �꽕�젙�빀�땲�떎.
        OffImage[0].gameObject.SetActive(isMuted1);     // SFX �넗湲��쓽 鍮꾪솢�꽦�솕 �씠誘몄��瑜� �꽕�젙�빀�땲�떎.
        OnImage[1].gameObject.SetActive(!isMuted2);     // BGM �넗湲��쓽 �솢�꽦�솕 �씠誘몄��瑜� �꽕�젙�빀�땲�떎.
        OffImage[1].gameObject.SetActive(isMuted2);     // BGM �넗湲��쓽 鍮꾪솢�꽦�솕 �씠誘몄��瑜� �꽕�젙�빀�땲�떎.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }
}