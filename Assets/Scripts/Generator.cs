
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//(1.0 ~ 0.8) 사이로 만들고 함수 정리 
public class Generator : MonoBehaviour
{
    public GameObject[] gFruits  = null;
    public GameObject[] mainfood;
    public GameObject[] subfood;
   
    [SerializeField]
    private GameObject spawn;
    
    [SerializeField]
    private GameObject NPC;
    
    [SerializeField]
    private float[][] fSpanArray = new float[][]
    {
        new float[] {1.0f, 1.0f, 1.0f, 1.0f},
        new float[] {1.0f, 0.8f, 0.8f, 1.0f, 1.0f},
        new float[] {0.8f, 1.0f, 0.8f, 0.8f, 1.0f ,0.8f},
        new float[] {0.8f ,0.9f, 0.8f, 0.9f, 0.8f, 1.0f},
        new float[] {1.0f, 0.9f, 0.9f, 1.0f, 0.8f, 1.0f},
    };

    [SerializeField]
    private float[] fSpeed = new float[] { 1.0f, 0.9f, 0.8f, 0.7f, 0.6f }; // if recipe success ,spanArray speed fast  
    [SerializeField]
    private float fTimeElapsed = 0.0f;
    [SerializeField]
    private int iRowIndex = 0;
    [SerializeField]
    private int iColIndex = 0;

    void Start()
    {
        mainfood = Resources.LoadAll<GameObject>("Prefabs/MainFood");
        subfood = Resources.LoadAll<GameObject>("Prefabs/SubFood");
        iRowIndex = UnityEngine.Random.Range(0, fSpanArray.Length);
        NPC = GameObject.Find("NPC");
    }

    void Update()
    {
        fTimeElapsed += Time.deltaTime;
        if (fTimeElapsed >= GetCurrentSpan() && GameDirector.hp > 0)
        {
            NPC.GetComponent<NPCController>().Drawing();
            SpawnFood();
            fTimeElapsed = 0;

            if (iColIndex == fSpanArray[iRowIndex].Length - 1)
            {
                UpdateIndices();
            }
            else
            {
                iColIndex++;
            }
        }
    }
    public void SpawnFood()
    {
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        GameObject foodPrefab;
        int itemHp;

        if (UnityEngine.Random.Range(0, 3) == 0)
        {
            foodPrefab = mainfood[UnityEngine.Random.Range(0, mainfood.Length)];
            itemHp = 2;
        }
        else
        {
            foodPrefab = subfood[UnityEngine.Random.Range(0, subfood.Length)];
            itemHp = 1;
        }

        spawn = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        spawn.name = foodPrefab.name;
        spawn.GetComponent<ItemController>().itemHp = itemHp;
    }
    private float GetCurrentSpan()
    {
        return fSpanArray[iRowIndex][iColIndex];
    }

    private void UpdateIndices()
    {
        iRowIndex = UnityEngine.Random.Range(0, fSpanArray.Length);
        iColIndex = 0;
    }


}


