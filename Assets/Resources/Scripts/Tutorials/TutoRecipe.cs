using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoRecipe : MonoBehaviour
{
    public TextMeshProUGUI tt = null;
    private enum TutorialState { ment1, ment2, ment3, ment4 }
    private TutorialState currentState;

    private void Start()
    {
        GameDirector.isTouch = false;
        currentState = TutorialState.ment1;
    }


    void Update()
    {
        switch (currentState)
        {
            case TutorialState.ment1:
                tt.text = "각 음식들은 서로 다른 레시피를 가지고 있습니다.";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState.ment2;
                }
                break;
            case TutorialState.ment2:
                tt.text = "재료의 종류와 갯수에 맞추어 냄비에 넣고 요리를 완성 하세요!";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState.ment3;
                }
                break;
            case TutorialState.ment3:
                tt.text = "레시피를 완성할 때마다 300점을 얻게됩니다!";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState.ment4;

                }
                break;
            case TutorialState.ment4:
                tt.text = "단! <color=red>레시피에 맞지 않는 재료</color>나 <color=red>더 많은 재료</color>가 들어갈 시 <color=red>즉시 게임이 종료</color>되므로 주의해 주세요!";

                GameDirector.isTouch = true;
                TutoAtkRange.availableMove = true;           
                Invoke("TouchControll", 0.5f);


                break;
            default:
                tt.text = "Error";
                break;
        }
    }



    void TouchControll()
    {
        GameDirector.isTouch = false;
    }

}
