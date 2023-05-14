using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    void Start()
    {

    }
    void Update()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
