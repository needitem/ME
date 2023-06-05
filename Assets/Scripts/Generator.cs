using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RZP;

public class Generator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] fruits;
    public GameObject[] meats;

    public GameObject[] mainfood;
    public GameObject[] subfood;
    private BPMDetector bPMDetector;


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

        bPMDetector = new BPMDetector("C:\\Users\\user\\Desktop\\music1 (online-audio-converter.com).wav");
        StartCoroutine(MeasureBPM());

    }

    // Update is called once per frame
    void Update()
    {
        if(GameDirector.hp != 0 && timeElapsed >= span)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= span)
            {
                SpawnFood();
                timeElapsed = 0f;
            }
        }
    }
    IEnumerator MeasureBPM()
    {
        // 음원을 로드하고 BPM을 측정하는 데에 필요한 시간을 대기합니다.
        yield return new WaitForSeconds(1f);

        float bpm = bPMDetector.getBPM();

        span = 60f / bpm;

        // BPM 측정이 완료되면 노드를 생성합니다.
        SpawnFood();
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




