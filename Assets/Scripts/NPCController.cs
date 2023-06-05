using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Animator npcAnimator;
    // npc컨트롤러에서 사용하기 위한 변수
    public static bool isDrawing;

    // Start is called before the first frame update
    void Start()
    {
        npcAnimator = GetComponent<Animator>();
        isDrawing = false; //시작할때 초기화
    }

    // Update is called once per frame
    void Update()
    {

        //isDrawing이 true면 던지는 애니메이션이 나온다. isDrawing은 제너레이터 스크립트에서 프리팹이 생성될때 true가 된다.
        if (isDrawing == true) {
            npcAnimator.SetTrigger("drawing");
            isDrawing = false; // 던졌으면 초기화
        }


    }
}
