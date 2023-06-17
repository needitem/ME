
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//(1.0 ~ 0.8) 사이로 만들고 함수 정리 
public class Generator : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    public GameObject[] mainFood;
    public GameObject[] subFood;
    private GameObject spawn;
    private GameObject NPC;
    private float[][] spanArray = new float[][]
    {
        new float[] {1.0f, 1.0f, 1.0f, 1.0f},
        new float[] {1.0f, 0.5f, 0.5f, 1.0f, 1.0f},
        new float[] {0.4f, 0.4f, 0.7f, 0.5f, 1.0f},
        new float[] {0.25f, 0.25f, 0.6f, 0.8f, 0.6f, 1.0f, 0.5f},
        new float[] {0.6f, 0.9f, 0.5f, 1.0f}
    };

    private float timeElapsed = 0f;
    private int rowIndex = 0;
    private int colIndex = 0;

    public float span = 1.3f;

    void Start()
    {
        mainFood = Resources.LoadAll<GameObject>("Prefabs/MainFood"); 
        subFood = Resources.LoadAll<GameObject>("Prefabs/SubFood"); 
        rowIndex = Random.Range(0, spanArray.Length);
        NPC = GameObject.Find("NPC");
>>>>>>> 037113a09a7e88abd2eaff2a99f17905796a941d
    }

    void Update()
    {
<<<<<<< HEAD
        fTimeElapsed += Time.deltaTime;
        if (fTimeElapsed >= GetCurrentSpan() && GameDirector.hp > 0)
        {
            gNPC.GetComponent<NPCController>().Drawing();
            SpawnFood();
            fTimeElapsed = 0;
=======
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= GetCurrentSpan() && GameDirector.hp > 0) // generate food every span seconds
        {
            NPC.GetComponent<NPCController>().Drawing(); // NPC throw food animation
            SpawnFood();
            timeElapsed = 0; // reset timer
>>>>>>> 037113a09a7e88abd2eaff2a99f17905796a941d

            if (iColIndex == fSpanArray[iRowIndex].Length - 1)
            {
                UpdateIndices(); // update indices for next spawn
            }
            else
            {
                iColIndex++;
            }
        }
    }

    public void SpawnFood() // spawn food
    {
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        GameObject foodPrefab;
        int itemHp;

<<<<<<< HEAD
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
=======
        if (Random.Range(0, 3) == 0) // 1/3 chance to spawn main food. set bigger value to increase chance
        {
            foodPrefab = mainFood[Random.Range(0, mainFood.Length)];
            itemHp = 2; // main food has 2 hp
        }
        else
        {
            foodPrefab = subFood[Random.Range(0, subFood.Length)];
            itemHp = 1; // sub food has 1 hp

        }

        spawn = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        spawn.name = foodPrefab.name; // set name of food to its prefab name. prevent (prefab) in hierarchy
        spawn.GetComponent<ItemController>().itemHp = itemHp;
>>>>>>> 037113a09a7e88abd2eaff2a99f17905796a941d
    }

    private float GetCurrentSpan() // get current span
    {
        gSuccessCount = GameObject.Find("gameDirector");
        return fSpanArray[iRowIndex][iColIndex];//* fSpeed[gSuccessCount.GetComponent<Recipe>().SuccessRecipe];
    }

    private void UpdateIndices()
    {
<<<<<<< HEAD
        iRowIndex = UnityEngine.Random.Range(0, fSpanArray.Length);
        iColIndex = 0;
    }


=======
        rowIndex = Random.Range(0, spanArray.Length); // update row index
        colIndex = 0;
    }
>>>>>>> 037113a09a7e88abd2eaff2a99f17905796a941d
}
