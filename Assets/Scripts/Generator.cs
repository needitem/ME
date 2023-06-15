
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//(1.0 ~ 0.8) 사이로 만들고 함수 정리 
public class Generator : MonoBehaviour
{
    public GameObject[] gFruits  = null;
    public GameObject[] gMainfood;
    public GameObject[] gSubfood;

    [SerializeField]
    public GameObject gSuccessCount;

    [SerializeField]
    private GameObject gSpawn;
    
    [SerializeField]
    private GameObject gNPC;
    
    [SerializeField]
    private float[][] fSpanArray = new float[][]
    {
        new float[] {1.5f, 1.5f, 1.5f , 1.5f},
        new float[] {1.3f, 1.2f, 1.3f, 1.2f},
        new float[] {1.5f, 1.1f, 1.4f, 1.5f},
        new float[] {1.3f, 1.2f, 1.0f, 1.2f, 1.3f},
        new float[] {1.4f , 1.1f, 1.1f, 1.4f, 1.0f},
        new float[] {1.2f, 1.1f, 1.5f, 1.2f, 1.1f}
    };

   
    // private float[] fSpeed = new float[] { 1.0f, 0.9f,0.8f,0.7f,0.6f,0.55f,0.5f}; if recipe success ,spanArray speed fast  
    [SerializeField]
    private float fTimeElapsed = 0.0f;
    [SerializeField]
    private int iRowIndex = 0;
    [SerializeField]
    private int iColIndex = 0;

    void Start()
    {
        gMainfood = Resources.LoadAll<GameObject>("Prefabs/MainFood");
        gSubfood = Resources.LoadAll<GameObject>("Prefabs/SubFood");
        iRowIndex = UnityEngine.Random.Range(0, fSpanArray.Length);
        gNPC = GameObject.Find("NPC");
    }

    void Update()
    {
        fTimeElapsed += Time.deltaTime;
        if (fTimeElapsed >= GetCurrentSpan() && GameDirector.hp > 0)
        {
            gNPC.GetComponent<NPCController>().Drawing();
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
            foodPrefab = gMainfood[UnityEngine.Random.Range(0, gMainfood.Length)];
            itemHp = 2;
        }
        else
        {
            foodPrefab = gSubfood[UnityEngine.Random.Range(0, gSubfood.Length)];
            itemHp = 1;
        }

        gSpawn = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        gSpawn.name = foodPrefab.name;
        gSpawn.GetComponent<ItemController>().itemHp = itemHp;
    }
    private float GetCurrentSpan()
    {
        gSuccessCount = GameObject.Find("gameDirector");
        return fSpanArray[iRowIndex][iColIndex];//* fSpeed[gSuccessCount.GetComponent<Recipe>().SuccessRecipe];
    }

    private void UpdateIndices()
    {
        iRowIndex = UnityEngine.Random.Range(0, fSpanArray.Length);
        iColIndex = 0;
    }


}


