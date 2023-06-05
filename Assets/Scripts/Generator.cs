using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] fruits;
    public GameObject[] meats;

    public GameObject[] mainfood;
    public GameObject[] subfood;


   
    public static GameObject spawn;
    //public static int randomIndex;
    public static int MainRandomIndex;
    public static int SubRandomIndex;



    private float timeElapsed = 0f;
    public float span = 0.3f;

    //private int difficulty = 1;
    void Start()
    {
        fruits = Resources.LoadAll<GameObject>("Prefabs");
        mainfood = Resources.LoadAll<GameObject>("MainFood");
        subfood = Resources.LoadAll<GameObject>("SubFood");
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= span)
        {
            SpawnFood();
            //SpawnFruit();
            timeElapsed = 0f;
        }
    }

    public int getMainFoodRandom()
    {
        int MainRandomIndex = Random.Range(0, mainfood.Length);     
        return MainRandomIndex;
    }

    public int getSubFoodRandom()
    {        
        int SubRandomIndex = Random.Range(0, subfood.Length);
        return SubRandomIndex;
    }

    //private void SpawnFruit()
    //{

    //    randomIndex = getRandom();
    //    Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
    //    spawn = Instantiate(fruits[randomIndex], spawnPosition, Quaternion.identity);

    //}

    public void SpawnFood()
    {
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        
       
        MainRandomIndex = getMainFoodRandom();
        SubRandomIndex = getSubFoodRandom();

        switch (Random.Range(0, 3))
        {

            case 0:
                spawn = Instantiate(mainfood[MainRandomIndex], spawnPosition, Quaternion.identity);
                spawn.GetComponent<ItemController>().itemHp = 2;
                break;
            default:
                spawn = Instantiate(subfood[SubRandomIndex], spawnPosition, Quaternion.identity);
                spawn.GetComponent<ItemController>().itemHp = 1;
                break;
        }


        
    }


}




