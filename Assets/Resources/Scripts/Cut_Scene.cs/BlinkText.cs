using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    private float nOpacity = 1; // 투명도

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void FixedUpdate() //고정 프레임 속도
    {
        if (nOpacity < 0.5f) //투명도가 0.5이하
        {
           GetComponent<Text>().color = new Color(1,0,0, 1 - nOpacity); //Color의 투명도(알파)부분을 nOpacity만큼 뺀만큼 출력
        }
        else 
        {
            GetComponent<Text>().color = new Color(1,0,0, nOpacity); //Color의 투명도부분을 nOpacity만큼 뺀만큼 출력
            if (nOpacity > 1)//투명도가 1이상이 되면 초기화 
            { 
                nOpacity = 0;
            }
        }
        nOpacity += 0.015f;
    }
}
