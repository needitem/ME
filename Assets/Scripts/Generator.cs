using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] fruits;
    float span = 2.0f;
    float delta = 0;

    void Start()
    {
        fruits = new GameObject[] { Resources.Load<GameObject>("Prefabs/Green"), Resources.Load<GameObject>("Prefabs/Yellow") };
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if(delta > span)
        {
            delta += Time.deltaTime;
            if (delta > span)
            {
                delta = 0;

                // instantiate a random circle prefab at position (0,0,0)
                int randomIndex = Random.Range(0, fruits.Length);
                Instantiate(fruits[randomIndex], new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }
}
