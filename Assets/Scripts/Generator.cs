<<<<<<< HEAD
using System;
using System.Collections;
using System.Collections.Generic;
=======
>>>>>>> 2546139089f266ebfbd899b92eec408dd97c2540
using UnityEngine;
//(1.0 ~ 0.8) 사이로 만들고 함수 정리 
public class Generator : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject[] gFruits  = null;
    [SerializeField]
    private float[][] fSpanArray = new float[][]
=======
    public GameObject[] mainfood;
    public GameObject[] subfood;
    private GameObject spawn;
    private GameObject NPC;
    private float[][] spanArray = new float[][]
>>>>>>> 2546139089f266ebfbd899b92eec408dd97c2540
    {
        new float[] {1.0f, 1.0f, 1.0f, 1.0f},
        new float[] {1.0f, 0.8f, 0.8f, 1.0f, 1.0f},
        new float[] {0.8f, 1.0f, 0.8f, 0.8f, 1.0f ,0.8f},
        new float[] {0.8f ,0.9f, 0.8f, 0.9f, 0.8f, 1.0f},
        new float[] {1.0f, 0.9f, 0.9f, 1.0f, 0.8f, 1.0f},
    };

    [SerializeField]
    private float fTimeElapsed = 0.0f;
    [SerializeField]
    private int iRowIndex = 0;
    [SerializeField]
    private int iColIndex = 0;

    public float span = 1.3f;


    void Start()
    {
<<<<<<< HEAD
        gFruits = Resources.LoadAll<GameObject>("Prefabs");
        iRowIndex = Random.Range(0, fSpanArray.Length);
=======
        mainfood = Resources.LoadAll<GameObject>("Prefabs/MainFood");
        subfood = Resources.LoadAll<GameObject>("Prefabs/SubFood");
        rowIndex = Random.Range(0, spanArray.Length);
        NPC = GameObject.Find("NPC");
>>>>>>> 2546139089f266ebfbd899b92eec408dd97c2540
    }

    void Update()
    {
<<<<<<< HEAD
        Bitupdate();
    }

    void Bitupdate()
    {
        fTimeElapsed += Time.deltaTime;
        if (fTimeElapsed >= GetCurrentSpan())
        {
            SpawnFruit();
            fTimeElapsed = 0f;
            if (iColIndex == fSpanArray[iRowIndex].Length - 1)
=======
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= GetCurrentSpan() && GameDirector.hp > 0)
        {
            NPC.GetComponent<NPCController>().Drawing();
            SpawnFood();
            timeElapsed = 0;

            if (colIndex == spanArray[rowIndex].Length - 1)
>>>>>>> 2546139089f266ebfbd899b92eec408dd97c2540
            {
                UpdateIndices();
            }
            else
            {
                iColIndex++;
            }
        }
    }
<<<<<<< HEAD
    private float GetCurrentSpan()
    {
        
        return fSpanArray[iRowIndex][iColIndex];
=======
    public void SpawnFood()
    {
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        GameObject foodPrefab;
        int itemHp;

        if (Random.Range(0, 3) == 0)
        {
            foodPrefab = mainfood[Random.Range(0, mainfood.Length)];
            itemHp = 2;
        }
        else
        {
            foodPrefab = subfood[Random.Range(0, subfood.Length)];
            itemHp = 1;
        }

        spawn = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        spawn.name = foodPrefab.name;
        spawn.GetComponent<ItemController>().itemHp = itemHp;
    }
    private float GetCurrentSpan()
    {
        return spanArray[rowIndex][colIndex];
>>>>>>> 2546139089f266ebfbd899b92eec408dd97c2540
    }

    private void UpdateIndices()
    {
        iRowIndex = Random.Range(0, fSpanArray.Length);
        iColIndex = 0;
    }

<<<<<<< HEAD
    private void SpawnFruit()
    {
        int randomIndex = Random.Range(0, gFruits.Length);
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        Instantiate(gFruits[randomIndex], spawnPosition, Quaternion.identity);
    }
=======
>>>>>>> 2546139089f266ebfbd899b92eec408dd97c2540
}


