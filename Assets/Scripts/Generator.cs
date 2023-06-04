using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] fruits;


    //====================
    public GameObject spawn;
    public GameObject leftHalf;
    public GameObject rightHalf;
    public GameObject half;
    Sprite[] sprite;
    Vector3 delPosition = Vector3.zero;
    //public GameObject[] halfFruits;
    public int randomIndex;
    //===================


    private float timeElapsed = 0f;
    public float span = 1f;

    //private int difficulty = 1;
    void Start()
    {
        fruits = Resources.LoadAll<GameObject>("Prefabs");


        sprite = Resources.LoadAll<Sprite>("SlicePrefabs");
        half = new GameObject("halfPrefab");

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
        if (leftHalf != null && leftHalf.transform.position.y <= -6.0f)
        {
            Destroy(leftHalf);
        }

        if (rightHalf != null && rightHalf.transform.position.y <= -6.0f)
        {
            Destroy(rightHalf);
        }
    }

    public int getRandom()
    {
        int randomIndex = Random.Range(0, fruits.Length);
        return randomIndex;
    }

    private void SpawnFruit()
    {
        //int randomIndex = Random.Range(0, fruits.Length);
        randomIndex = getRandom();
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        spawn = Instantiate(fruits[randomIndex], spawnPosition, Quaternion.identity);
        
    }

    public void Destroyfruits()
    {
        if (spawn != null && randomIndex != 2)
        {
            delPosition = spawn.transform.position;
            Destroy(spawn);
            LeftHalf(delPosition, randomIndex);
            RightHalf(delPosition, randomIndex);
           
        }
        else if(spawn != null && randomIndex == 2 && PlayerController.AtackCount == 2)
        {
            delPosition = spawn.transform.position;
            Destroy(spawn);
            LeftHalf(delPosition, randomIndex);
            RightHalf(delPosition, randomIndex);
        }
    }

    public void LeftHalf(Vector3 delPosition, int iRandom)
    {
        leftHalf = Instantiate(half, delPosition, Quaternion.identity);
        SpriteRenderer spriteRendererInstance = leftHalf.AddComponent<SpriteRenderer>();
        spriteRendererInstance.sprite = sprite[iRandom*2];
        Rigidbody2D rb = leftHalf.GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            rb = leftHalf.AddComponent<Rigidbody2D>();
            rb.gravityScale = 1f;

        }
    }

    public void RightHalf(Vector3 delPosition, int iRandom)
    {

        delPosition += new Vector3(1f, -0.3f, 0f);
        rightHalf = Instantiate(half, delPosition, Quaternion.identity);
        SpriteRenderer spriteRendererInstance = rightHalf.AddComponent<SpriteRenderer>();
        spriteRendererInstance.sprite = sprite[iRandom*2+1];
        Rigidbody2D rb = rightHalf.GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            rb = rightHalf.AddComponent<Rigidbody2D>();
            rb.gravityScale = 1f;

        }
    }


}





