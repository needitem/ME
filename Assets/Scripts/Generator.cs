using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NAudioBPM;


public class Generator : MonoBehaviour
{
    public GameObject[] fruits;

    private double timeElapsed = 0.0d;

    public double span = 0.0d;
    private BPMDetector bPMDetector;

    void Start()
    {
        fruits = Resources.LoadAll<GameObject>("Prefabs");
        bPMDetector = new BPMDetector("C:\\Users\\�߿�ȣ\\Desktop\\music1 (online-audio-converter.com).wav");
        StartCoroutine(MeasureBPM());
    }

    IEnumerator MeasureBPM()
    {
        // ������ �ε��ϰ� BPM�� �����ϴ� ���� �ʿ��� �ð��� ����մϴ�.
        yield return new WaitForSeconds(1f);

        double bpm = bPMDetector.getBPM();

        span = 60d / bpm;

        // BPM ������ �Ϸ�Ǹ� ��带 �����մϴ�.
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

    public int getMainFoodRandom()
    {
        int randomIndex = Random.Range(0, fruits.Length);
        Vector3 spawnPosition = new Vector3(15f, 1.5f, 1f);
        Instantiate(fruits[randomIndex], spawnPosition, Quaternion.identity);
    }
}
