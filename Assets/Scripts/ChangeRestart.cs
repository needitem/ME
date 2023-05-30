using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeRestart : MonoBehaviour
{
    // Start is called before the first frame update

    public void SceneChange()
    {
        SceneManager.LoadScene("GameScene");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
