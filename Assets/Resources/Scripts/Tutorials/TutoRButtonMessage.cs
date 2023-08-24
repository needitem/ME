using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoRButtonMessage : MonoBehaviour
{

    public TextMeshProUGUI tt = null;
    private enum TutorialState2 { ment1, ment2, ment3, ment4, ment5}
    private TutorialState2 currentState;
    [SerializeField] GameObject RButton;

    void Start()
    {
        GameDirector.isTouch = false;
        currentState = TutorialState2.ment1;
       
    }


    void Update()
    {
        switch (currentState)
        {
            case TutorialState2.ment1:
                //RButton.SetActive(true);
                RButton.gameObject.SetActive(true);
                tt.text = "이것은 공격 버튼입니다!";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment2; 
                }
                break;
            case TutorialState2.ment2:
                tt.text = "버튼을 누르면 사정거리 내에 있는 재료를 썰어낼 수 있습니다.";
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0)) 
                {
                    currentState = TutorialState2.ment3; 
                }
                break;
            case TutorialState2.ment3:
                tt.text = "잘게 썰린 재료들은 냄비에 들어가 맛있는 음식이 됩니다!";
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment4;
                }
                break;
            case TutorialState2.ment4:
                tt.text = "단! 레시피에 맞지 않게 재료를 썰어 넣을시 즉시 게임 오버입니다!";
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment5;
                }
                break;
            case TutorialState2.ment5:
                tt.text = "버튼을 눌러 보세요!";
                GameDirector.isTouch = true;
               
                Invoke("TouchControll", 0.5f);
                Invoke("delay", 3f);
                break;
                         
            //default:
            //    tt.text = "Error";
            //    break;
        }
    }

    void TouchControll()
    {
        GameDirector.isTouch = false;
    }

    void delay()
    {
        TutoRButton.availableMove2 = true;
    }

}
