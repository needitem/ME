using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover_sound : MonoBehaviour
{
    [SerializeField]
    public GameObject g;
    bool abc = true;
    // Start is called before the first frame update

    private void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        /*Debug.Log(g.activeSelf);*/
=======
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
        if (g.activeSelf == true && abc)
        {
            gameover();
            abc = false;
        }
    }

    public void gameover()
    {

        GetComponent<AudioSource>().Play();
    }
}
