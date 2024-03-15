using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameStart_FadeOut : MonoBehaviour
{
    // 게임 시작 메시지를 관리하기 위한 타이머 
    [SerializeField] 
    private float GameStartMs_Timer = 0;

    public static bool isMessageWait;

    GameObject GameStartText;

    public TextMeshProUGUI testMs;

    void Start()
    {

        //GameStartText = GetComponent<Text>();
        // 게임 시작시 카운트 초기화
        GameStartMs_Timer = 0;

        isMessageWait = true;
       


    }

    // Update is called once per frame
    void Update()
    {




        if (GameStartMs_Timer > 0.9f && GameStartMs_Timer <= 2f)
        {
            testMs.text = "READY";
        }
        else if (GameStartMs_Timer > 2f && GameStartMs_Timer <= 3f)
        {
            testMs.text = "GO!";
        }
        else if(GameStartMs_Timer >3f)
        {
            isMessageWait = false;
        }

        GameStartMs_Timer += Time.deltaTime;

    }


}
