using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{
    System.Random rRand = new System.Random();
    // Start is called before the first frame update
    public GameObject[] fruits;
    private double dtimeElapsed = 0.0d;
    public double dbpm = 0.0d; // bpm 

    //private int difficulty = 1;
    void Start()
    {
        fruits = Resources.LoadAll<GameObject>("Prefabs");
    }

    // Update is called once per frame
    void Update()
    {
        ObjectThrow();

    }

    private void SpawnFruit()
    {
        int randomIndex = Random.Range(0, fruits.Length);
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        Instantiate(fruits[randomIndex], spawnPosition, Quaternion.identity);
    }

    public void ObjectThrow() // 던졌을 때 true 값으로 받기

    {
        dtimeElapsed += Time.deltaTime;
        dbpm = Random.Range(120, 150); 
        if (dtimeElapsed >= 60d / dbpm) // 1초당 나오는 노트수 ex) 120 bpm이면 1초당 2개
        {
            SpawnFruit();
            dtimeElapsed -= 60d / dbpm;

        }
    }
}
