using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class katana_effect : MonoBehaviour
{
    Animator katanaAni;
    public static bool isHit;
    public static bool isDoubleHit;
    public static bool isPunch;
    // Start is called before the first frame update
    void Start()
    {
        katanaAni = GetComponent<Animator>();
        isHit = false;
        isDoubleHit = false;
        isPunch = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isHit == true)
        {
            this.katanaAni.SetTrigger("attack");
            isHit = false;
        }

        if (isDoubleHit == true)
        {
            this.katanaAni.SetTrigger("double_attack");
            isDoubleHit = false;
        }

        if (isPunch == true) 
        {
            this.katanaAni.SetTrigger("punch");
            isPunch = false;
        }

    }
}
