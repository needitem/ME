using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] fruits;
    private float[][] spanArray = new float[][]
    {
        new float[] {1.0f, 1.0f, 1.0f, 1.0f},
        new float[] {1.0f, 0.5f, 0.5f, 1.0f,1.0f},
        new float[] {0.4f, 0.4f, 0.7f, 0.5f, 1.0f},
        new float[] {0.25f, 0.25f, 0.6f, 0.8f, 0.6f, 1.0f, 0.5f},
        new float[] {0.6f, 0.9f,0.5f, 1.0f}
    };

    private float timeElapsed = 0f;
    private int rowIndex = 0;
    private int colIndex = 0;

    void Start()
    {
        fruits = Resources.LoadAll<GameObject>("Prefabs");
        rowIndex = Random.Range(0, spanArray.Length);
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= GetCurrentSpan())
        {
            SpawnFruit();
            timeElapsed = 0f;
            if (colIndex == spanArray[rowIndex].Length - 1)
            {
                UpdateIndices();
            }
            else
            {
                colIndex++;
            }
        }
    }

    private float GetCurrentSpan()
    {
        
        return spanArray[rowIndex][colIndex];
    }

    private void UpdateIndices()
    {
        rowIndex = Random.Range(0, spanArray.Length);
        colIndex = 0;
    }

    private void SpawnFruit()
    {
        int randomIndex = Random.Range(0, fruits.Length);
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        Instantiate(fruits[randomIndex], spawnPosition, Quaternion.identity);
    }
}
