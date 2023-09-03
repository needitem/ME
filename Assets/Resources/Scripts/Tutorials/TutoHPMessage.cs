using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoHPMessage : MonoBehaviour
{
    [SerializeField] GameObject Heart;
    [SerializeField] GameObject Carrot;
    [SerializeField] GameObject black1, black2;
    public TextMeshProUGUI tt = null;
    private enum TutorialState2 { ment1, ment2, ment3, ment4, ment5}
    private TutorialState2 currentState;
    bool one = true;
    [SerializeField] GameObject LButton, RButton;
    void Start()
    {
        black1.SetActive(false);
        black2.SetActive(false);
        GameDirector.isTouch = false;
        currentState = TutorialState2.ment1;
    }


    void Update()
    {
        Destroy(Carrot);
        switch (currentState)
        {
            case TutorialState2.ment1:
                Time.timeScale = 1.0f;
                tt.text = "마지막으로 체력입니다.";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment2; 
                }
                break;
            case TutorialState2.ment2:
                Heart.gameObject.SetActive(true);
                black1.SetActive(true);
                black2.SetActive(true);
                tt.text = "사무라이의 체력인 하트는 총 세 개가 있습니다.";
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0)) 
                {
                    currentState = TutorialState2.ment3; 
                }
                break;
            case TutorialState2.ment3:
                tt.text = "날라오는 재료에 맞게 될 시 체력을 하나 잃게 됩니다.";
                black1.SetActive(false);
                black2.SetActive(false);
                LButton.GetComponent<Button>().interactable = false;
                RButton.GetComponent<Button>().interactable = false;
                if (one)
                {
                    TutorialsManager.isGo = true;
                    //TutorialsManager.isGo = false;
                    Invoke("IsFoodStop", 0.1f);
                    
                    one = false;
                }
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment4;
                }
                break;
            case TutorialState2.ment4:
                tt.text = "체력을 모두 잃게되면 게임이 종료됩니다.";
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment5;
                }
                break;
            case TutorialState2.ment5:             
                tt.text = "자 그럼 최대한 많은 레시피를 완성시켜 최고의 요리사가 되어보세요!";
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
   

    void IsFoodStop()
    {
        TutorialsManager.isGo = false;
    }

}
