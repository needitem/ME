using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] fruits;
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
        if(GameDirector.hp != 0)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= span)
            {
                SpawnFruit();
                timeElapsed = 0f;
            }
        }
 

        /*       if (timeElapsed >= 60d/ span)
                {
                    SpawnFruit();
                    timeElapsed -= 60d / span;
                }*/
    }

    private void SpawnFruit()
    {
        int randomIndex = Random.Range(0, fruits.Length);
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        Instantiate(fruits[randomIndex], spawnPosition, Quaternion.identity);
    }
}
