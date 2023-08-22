using Unity.VisualScripting;
using UnityEngine;
using System.IO;

public class Generator : MonoBehaviour
{
    public static bool isTouch = false;// 튜토리얼에서 터치를 했는가 알려주는 스위치변수
    [SerializeField] public int maxHp = 3;              // 플레이어의 최대 HP
    [SerializeField] public Image[] heartImages;        // 플레이어의 HP를 나타내는 하트 이미지 배열
    [SerializeField] GameObject[] gIngredient_cnt;      // 재료 개수 텍스트를 나타내는 게임 오브젝트 배열
    [SerializeField] public GameObject Gameover_Panel;  // 게임 오버 패널 오브젝트

    private GameObject spawn; // ������ ��Ḧ ����
    private GameObject NPC; //  NPC �Ծ� ������Ʈ 
    AudioDirector audioDirector;
    AudioSource audioSource;
    public RandomBGM randomBGM;

    public int bgmIndex = 0;
    private float spawnTime = 0f; //����� �ð�
    private int index = 0; // �ؽ�Ʈ ���� �о�� �ð��� �ε���

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
            NextSpawnTime(); // ���� ������ ������ �ð� ������Ʈ
        }

        if (GameDirector.hp <= 0)
        {
            audioDirector.SoundMute(true);
        }
    }

    private void ReadTrackFile()
    {
        string filePath = $"Assets/BGM_text/Track_{bgmIndex}.txt"; // Track_1.txt ������ ��� ����

        if (File.Exists(filePath))
        {
            // ������ �����ϴ� ��쿡�� �б� �õ�
            StreamReader reader = new StreamReader(filePath);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (float.TryParse(line, out float time))
                {
                    // �ð��� ���ڷ� �Ľ��Ͽ� spawnTime�� ����
                    spawnTime = time;
                    break;
                }
            }

            reader.Close();
        }
    }

    private void NextSpawnTime()
    {
        // ���� ���� ������ �ð� ������Ʈ
        index++;
        if (index < 0 || index >= File.ReadAllLines($"Assets/BGM_text/Track_{bgmIndex}.txt").Length)
        {
            // ������ ��� ������ ��� �� �̻� �������� ����
            spawnTime = float.MaxValue;
        }

        else
        {
            // ���� ���� ������ �ð� ����
            spawnTime = float.Parse(File.ReadAllLines($"Assets/BGM_text/Track_{bgmIndex}.txt")[index]);
        }
    }


    public void SpawnFood() // ���� ����
    {
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        GameObject foodPrefab;
        int itemHp;

        if (Random.Range(0, 3) == 0) // 1/3�� Ȯ���� �ֿ� ���� ����
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
        spawn.name = foodPrefab.name; // ������ �̸��� ������ �̸����� �����Ͽ� ������������ �������̶�� ǥ�ø� ����
        spawn.GetComponent<ItemController>().itemHp = itemHp;
    }

    public void ChangeBGM(int newBGMIndex)
    {
        randomBGM.currentBGMIndex = newBGMIndex; // RandomBGM ��ũ��Ʈ�� currentBGMIndex ������Ʈ
        ReadTrackFile(); // ���ο� BGM�� �ش��ϴ� Track ���� �б�
    }
}