using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{


    [SerializeField] private Slider hpBar;
    [SerializeField] private int maxHp = 10;
    static public int hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        hpBar.value = (float)hp / (float)maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        HandleHp();
    }

    private void HandleHp()
    {
        hpBar.value = (float)hp / (float)maxHp;
    }
}
