using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CUTDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SkipScene", 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    public void SkipScene() 
    { //skip 버튼에 연결하여 클릭할 시 바로 게임씬으로 전환
        SceneDirector.ChangeScene1();
    }
}
