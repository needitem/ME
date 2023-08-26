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
    static public int index = 0;
    private int song = 0;

    List<List<string>> timeArray = new List<List<string>>();
    List<string> temp = new List<string>();
    float deltatime = 0.0f;

    public bool one = true;

    private float fDelayBit = 0.3f;

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

        if (deltatime >= float.Parse(timeArray[song][index]) - fDelayBit && GameDirector.hp > 0 && !one)
        {
            SpawnFood();
            Debug.Log("time: " + float.Parse(timeArray[song][index]));
            try{ index++; }
            catch {song = RandomBGM.currentBGMIndex; }
            
        }

        if (GameDirector.hp <= 0)
        {
            audioDirector.SoundMute(true);
        }
    }

    private void ReadTrackFile()
    {
        string filePath = $"Assets/BGM_text";
        string[] txtFiles = Directory.GetFiles(filePath, "*.txt");
        foreach (string file in txtFiles)
        {
            
            StreamReader sr = new StreamReader(file);
            if (sr != null)
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    temp.Add(line);
                }
            }
            timeArray.Add(new List<string>(temp));
            temp.Clear();
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




        NPC.GetComponent<NPCController>().Drawing(); //������ �ִϸ��̼�
        audioDirector.SoundPlay("Sound/effect_sound/Kick"); // �巳 kick�Ҹ�
        spawn = Instantiate(foodPrefab, spawnPosition, Quaternion.identity); //������ ����
        spawn.name = foodPrefab.name;
        spawn.GetComponent<ItemController>().itemHp = itemHp;
    }
}