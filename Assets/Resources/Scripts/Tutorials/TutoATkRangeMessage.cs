using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoATkRangeMessage : MonoBehaviour
{
    public TextMeshProUGUI tt = null;
    private enum TutorialState2 { ment1, ment2, ment3}
    private TutorialState2 currentState;

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
                tt.text = "타격 범위 입니다.";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment2; 
                }
                break;
            case TutorialState2.ment2:
                tt.text = "해당 범위내에 재료가 들어올시 썰어내거나 튕겨내어야 합니다.";
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0)) 
                {
                    currentState = TutorialState2.ment3; 
                }
                break;
            case TutorialState2.ment3:
                //tt.text = "타이밍이 어긋날 시 재료에 맞을 수 있으니 주의 해 주세요!";
                tt.text = "타이밍이 어긋날 시 재료에 맞을 수 있으니 주의 해 주세요!";
                GameDirector.isTouch = true;
                
                Invoke("TouchControll", 0.5f);
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

}
