using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//(1.0 ~ 0.8) 사이로 만들고 함수 정리 
public class Generator : MonoBehaviour
{
    public GameObject[] gFruits  = null;
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
    private float fTimeElapsed = 0.0f;
    [SerializeField]
    private int iRowIndex = 0;
    [SerializeField]
    private int iColIndex = 0;

    void Start()
    {
        gFruits = Resources.LoadAll<GameObject>("Prefabs");
        iRowIndex = Random.Range(0, fSpanArray.Length);
    }

    void Update()
    {
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
            {
                UpdateIndices();
            }
            else
            {
                iColIndex++;
            }
        }
    }
    private float GetCurrentSpan()
    {
        
        return fSpanArray[iRowIndex][iColIndex];
    }

    private void UpdateIndices()
    {
        iRowIndex = Random.Range(0, fSpanArray.Length);
        iColIndex = 0;
    }

    private void SpawnFruit()
    {
        int randomIndex = Random.Range(0, gFruits.Length);
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        Instantiate(gFruits[randomIndex], spawnPosition, Quaternion.identity);
    }
}
