using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoConcept : MonoBehaviour
{
    [SerializeField]
    //public static bool isTouch = false;
    GameObject RButton;
    [SerializeField]
    GameObject LButton;
    [SerializeField]
    GameObject Heart;

    public TextMeshProUGUI tt = null;

    private void Start()
    {
        Heart.gameObject.SetActive(false);
        RButton.gameObject.SetActive(false);
        LButton.gameObject.SetActive(false);
        GameDirector.isTouch = false;
        tt.text = "안녕하세요 고기싸무라이 튜토리얼 입니다!";
    }
    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetMouseButtonDown(0))
        {
            tt.text = "고기싸무라이는 미식가(npc)가 던지는 각종 재료들을 레시피에 맞추어 요리를 하는 게임입니다.";
            GameDirector.isTouch = true;
            Invoke("TouchControll", 0.5f);
        }
        
    }
    void TouchControll()
    {
        GameDirector.isTouch = false;
    }
}
