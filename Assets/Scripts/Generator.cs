using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NAudioBPM;

public class Generator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] fruits;
    public GameObject[] meats;

    public static GameObject spawn;
    public static int randomIndex;

    private float timeElapsed = 0f;
    public float span = 1f;

    //private int difficulty = 1;
    void Start()
    {
        fruits = Resources.LoadAll<GameObject>("Prefabs");
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= span)
        {
            SpawnFruit();
            timeElapsed = 0f;
        }
    }

    public int getRandom()
    {
        int randomIndex = Random.Range(0, fruits.Length);
        return randomIndex;
    }

    private void SpawnFruit()
    {
        randomIndex = getRandom();
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        spawn = Instantiate(fruits[randomIndex], spawnPosition, Quaternion.identity);

    }



}




