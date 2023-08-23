using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class Generator : MonoBehaviour
{
    [SerializeField]
    public GameObject[] mainFood;
    [SerializeField]
    public GameObject[] subFood;

    private GameObject spawn;
    private GameObject NPC;
    AudioDirector audioDirector;
    AudioSource audioSource;
    public RandomBGM randomBGM;

    public int bgmIndex = 1;
    private int index = 0;

    List<string> timeArray = new List<string>();
    float deltatime = 0.0f;

    public bool one = true;

    private void Awake()
    {
        ReadTrackFile();
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioDirector = GetComponent<AudioDirector>();
        mainFood = Resources.LoadAll<GameObject>("Prefabs/MainFood");
        subFood = Resources.LoadAll<GameObject>("Prefabs/SubFood");
        NPC = GameObject.Find("NPC");
        randomBGM = FindObjectOfType<RandomBGM>();

    }

    void Update()
    {
        deltatime += Time.deltaTime;
        if (!GameStart_FadeOut.isMessageWait && one) {deltatime = 0.0f; one = false; }

        if (deltatime >= float.Parse(timeArray[index]) && GameDirector.hp > 0 && !one)
        {
            SpawnFood();
            Debug.Log("time: " + float.Parse(timeArray[index]));
            index++;
        }

        if (GameDirector.hp <= 0)
        {
            audioDirector.SoundMute(true);
        }
    }

    private void ReadTrackFile()
    {
        string filePath = $"Assets/BGM_text/Track_1.txt";
        StreamReader sr = new StreamReader(filePath);
        if (sr != null)
        {
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                timeArray.Add(line);
            }
        }
    }

    public void SpawnFood()
    {
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        GameObject foodPrefab;
        int itemHp;

        if (Random.Range(0, 3) == 0)
        {
            foodPrefab = mainFood[Random.Range(0, mainFood.Length)];
            itemHp = 1; // main food has 1 hp
                        //  audioDirector.SoundPlay("Sound/effect_sound/throw_main");

        }
        else
        {
            foodPrefab = subFood[Random.Range(0, subFood.Length)];
            itemHp = 1; // sub food has 1 hp
                        // audioDirector.SoundPlay("Sound/effect_sound/throw_sub");

        }

        spawn = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        spawn.name = foodPrefab.name;
        spawn.GetComponent<ItemController>().itemHp = itemHp;
    }
}