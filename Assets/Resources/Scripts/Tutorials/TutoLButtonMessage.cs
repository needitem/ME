using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoLButtonMessage : MonoBehaviour
{

    GameObject fish;
    public TextMeshProUGUI tt = null;
    private enum TutorialState2 { ment1, ment2, ment3, ment4, ment5}
    private TutorialState2 currentState;
    [SerializeField] GameObject LButton;

    void Start()
    {
        fish = GameObject.Find("fish");
        GameDirector.isTouch = false;
        currentState = TutorialState2.ment1;
    }


    void Update()
    {
        Destroy(fish);
        switch (currentState)
        {
            case TutorialState2.ment1:
                LButton.gameObject.SetActive(true);
                tt.text = "방어 버튼입니다!";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment2; 
                }
                break;
            case TutorialState2.ment2:
                tt.text = "버튼을 누르면 사정거리 내에 있는 재료를 튕겨낼 수 있습니다.";
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0)) 
                {
                    currentState = TutorialState2.ment3; 
                }
                break;
            case TutorialState2.ment3:
                tt.text = "레시피에 맞지 않는 재료는 무조건 튕겨내어야 합니다!";
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment4;
                }
                break;
            case TutorialState2.ment4:
                tt.text = "물론 레시피 재료또한 튕겨 낼 수 있으나, 레시피가 완성이 되어야 점수가 올라가므로 유의해 주세요!";
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
