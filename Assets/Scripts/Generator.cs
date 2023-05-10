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
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if(delta > span)
        {
            delta = 0;
            GameObject fruit = Instantiate(fruits[Random.Range(0, fruits.Length)]);
            fruit.transform.position = new Vector3(0, 0, 0); //ø©±‚ πŸ≤„¡‡æﬂµ 
        }
    }
}
