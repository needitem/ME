using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RZP;

public class Generator : MonoBehaviour
{
    public GameObject[] mainfood;
    public GameObject[] subfood;

    private BPMDetector bPMDetector;
    private GameObject spawn;
    private int MainRandomIndex;
    private int SubRandomIndex;
    private float timeElapsed = 0f;
    public float span = 1.3f;

    void Start()
    {
        mainfood = Resources.LoadAll<GameObject>("MainFood");
        subfood = Resources.LoadAll<GameObject>("SubFood");

        //bPMDetector = new BPMDetector("C:\\Users\\user\\Desktop\\Music_1.wav");
        //StartCoroutine(MeasureBPM());
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= span)
        {
            SpawnFood();
            timeElapsed = 0;
        }
    }

    IEnumerator MeasureBPM()
    {
        yield return new WaitForSeconds(1f);

        float bpm = bPMDetector.getBPM();

        span = 60f / bpm;

        SpawnFood();
    }

    public void SpawnFood()
    {
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);

        GameObject foodPrefab;
        int itemHp;

        if (Random.Range(0, 3) == 0)
        {
            foodPrefab = mainfood[Random.Range(0, mainfood.Length)];
            itemHp = 2;
        }
        else
        {
            foodPrefab = subfood[Random.Range(0, subfood.Length)];
            itemHp = 1;
        }

        spawn = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        spawn.GetComponent<ItemController>().itemHp = itemHp;
    }
}
