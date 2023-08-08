using Unity.VisualScripting;
using UnityEngine;
using System.IO;

public class Generator : MonoBehaviour
{
    [SerializeField]
    public GameObject[] mainFood; // 주요 음식 프리팹 배열
    [SerializeField]
    public GameObject[] subFood; // 보조 음식 프리팹 배열

    private GameObject spawn; // 생성된 재료를 저장
    private GameObject NPC; //  NPC 게암 오브젝트 
    AudioDirector audioDirector;
    AudioSource audioSource;
    public RandomBGM randomBGM;

    public int bgmIndex = 0;
    private float spawnTime = 0f; //경과한 시간
    private int index = 0; // 텍스트 파일 읽어온 시간의 인덱스

    //private int Index = 0;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioDirector = GetComponent<AudioDirector>();
        mainFood = Resources.LoadAll<GameObject>("Prefabs/MainFood");
        subFood = Resources.LoadAll<GameObject>("Prefabs/SubFood");
        NPC = GameObject.Find("NPC");
        randomBGM = FindObjectOfType<RandomBGM>();
        ReadTrackFile();
    }

    void Update()
    {
        if (Time.time >= spawnTime && GameDirector.hp > 0)
        {
            SpawnFood();
            NextSpawnTime(); // 다음 음식을 생성할 시간 업데이트
        }

        if (GameDirector.hp <= 0)
        {
            audioDirector.SoundMute(true);
        }
    }

    private void ReadTrackFile()
    {
        string filePath = $"Assets/BGM_text/Track_{bgmIndex}.txt"; // Track_1.txt 파일의 경로 설정

        if (File.Exists(filePath))
        {
            // 파일이 존재하는 경우에만 읽기 시도
            StreamReader reader = new StreamReader(filePath);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (float.TryParse(line, out float time))
                {
                    // 시간을 숫자로 파싱하여 spawnTime에 저장
                    spawnTime = time;
                    break;
                }
            }

            reader.Close();
        }
    }

    private void NextSpawnTime()
    {
        // 다음 음식 생성할 시간 업데이트
        index++;
        if (index < 0 || index >= File.ReadAllLines($"Assets/BGM_text/Track_{bgmIndex}.txt").Length)
        {
            // 음식을 모두 생성한 경우 더 이상 생성하지 않음
            spawnTime = float.MaxValue;
        }

        else
        {
            // 다음 음식 생성할 시간 설정
            spawnTime = float.Parse(File.ReadAllLines($"Assets/BGM_text/Track_{bgmIndex}.txt")[index]);
        }
    }


    public void SpawnFood() // 음식 생성
    {
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        GameObject foodPrefab;
        int itemHp;

        if (Random.Range(0, 3) == 0) // 1/3의 확률로 주요 음식 생성
        {
            foodPrefab = mainFood[Random.Range(0, mainFood.Length)];
            itemHp = 2; // main food has 2 hp
            audioDirector.SoundPlay("Sound/effect_sound/throw_main");

        }
        else
        {
            foodPrefab = subFood[Random.Range(0, subFood.Length)];
            itemHp = 1; // sub food has 1 hp
            audioDirector.SoundPlay("Sound/effect_sound/throw_sub");

        }

        spawn = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        spawn.name = foodPrefab.name; // 음식의 이름을 프리팹 이름으로 설정하여 계층구조에서 프리랩이라는 표시를 방지
        spawn.GetComponent<ItemController>().itemHp = itemHp;
    }

    public void ChangeBGM(int newBGMIndex)
    {
        randomBGM.currentBGMIndex = newBGMIndex; // RandomBGM 스크립트의 currentBGMIndex 업데이트
        ReadTrackFile(); // 새로운 BGM에 해당하는 Track 파일 읽기
    }
}