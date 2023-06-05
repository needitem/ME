using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RZP;

public class Generator : MonoBehaviour
{
    public GameObject[] fruits;

    private double timeElapsed = 0.0d;

    public double span = 0.0d;
    private BPMDetector bPMDetector;

    void Start()
    {
        fruits = Resources.LoadAll<GameObject>("Prefabs");
        bPMDetector = new BPMDetector("C:\\Users\\추영호\\Desktop\\music1 (online-audio-converter.com).wav");
        StartCoroutine(MeasureBPM());
    }

    IEnumerator MeasureBPM()
    {
        // 음원을 로드하고 BPM을 측정하는 데에 필요한 시간을 대기합니다.
        yield return new WaitForSeconds(1f);

        double bpm = bPMDetector.getBPM();

        span = 60d / bpm;

        // BPM 측정이 완료되면 노드를 생성합니다.
        SpawnFruit();
    }

    void Update()
    {
        print(span);
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= span)
        {
            SpawnFruit();
            timeElapsed -= span;
        }
    }

    private void SpawnFruit()
    {
        int randomIndex = Random.Range(0, fruits.Length);
        Vector3 spawnPosition = new Vector3(15f, 1.5f, 1f);
        Instantiate(fruits[randomIndex], spawnPosition, Quaternion.identity);
    }
}