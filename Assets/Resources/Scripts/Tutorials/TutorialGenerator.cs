using Unity.VisualScripting;
using UnityEngine;


public class TutorialGenerator : MonoBehaviour
{
    [SerializeField]
    public GameObject[] mainFood; // 주요 음식 프리팹 배열
    [SerializeField]
    public GameObject[] subFood; // 보조 음식 프리팹 배열

    private GameObject spawn; // 생성된 재료를 저장
    private GameObject NPC; //  NPC 게암 오브젝트 
    AudioDirector audioDirector;
    AudioSource audioSource;

   


    private float[][] spanArray = new float[][] // 재료 생성 주기를 저장하는 2차원 배열
    {
        new float[] {1.0f, 0.9f, 0.9f, 1.0f},
        new float[] {1.0f, 0.8f, 0.8f, 1.0f,},
        new float[] {0.8f, 0.9f, 0.9f, 0.8f, 1.0f},
        new float[] {0.85f, 0.95f, 1.0f, 0.8f},
        new float[] {1.0f, 0.85f, 0.8f, 0.9f},
        new float[] {0.95f, 0.8f, 0.85f, 0.9f}
    };
    float timeScale = 1.0f;//시간 배율
    private float timeElapsed = 0f; //경과한 시간
    private int rowIndex = 0; // spanArray의 행 인덱스
    private int colIndex = 0; // spanArray의 열 인덱스
    private int gameSpeedUP = 0; // Spanspeed Index
    private int countSevenFood = 0; // 음식이 7회 생성 된 횟수

    //private int Index = 0;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioDirector = GetComponent<AudioDirector>();
        mainFood = Resources.LoadAll<GameObject>("Prefabs/MainFood");
        subFood = Resources.LoadAll<GameObject>("Prefabs/SubFood");
        rowIndex = Random.Range(0, spanArray.Length);
        NPC = GameObject.Find("NPC");
    }

    void Update()
    {
        timeElapsed += Time.deltaTime; // 경과한 시간 업데이트

        if (timeElapsed >= GetCurrentSpan() * timeScale && GameDirector.hp > 0 && TutorialsManager.isGo) //일정 시간마다 음식생성, hp가 0보다 큰 경우에만 실행
        {

            NPC.GetComponent<NPCController>().Drawing(); // NPC가 음식 던지는 에니매이션 실행
            SpawnFood(); // 음식생성
            Gamespeed(); // 게임 속도 조절
            timeElapsed = 0; // 타이머 초기화
            if (colIndex == spanArray[rowIndex].Length - 1) // 현재 행의 마지막열에 도달한 경우
            {
                UpdateIndices(); // 다음 생성을 위해 인덱스 업데이트
            }
            else
            {
                colIndex++; // 다음열로 이동
            }
        }
        if (GameDirector.hp <= 0)
        {
            audioDirector.SoundMute(true);
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

    private float GetCurrentSpan() // 련재 음식 생성주기 
    {
        return spanArray[rowIndex][colIndex]; // * speedArray[];
    }

    private void UpdateIndices()
    {
        rowIndex = Random.Range(0, spanArray.Length); // 행의 인덱스 업데이트
        colIndex = 0;
    }

    private void Gamespeed()
    {
        if (gameSpeedUP < 9) // 9보다 작은 경우 실행
        {
            if (countSevenFood == 7) //countSevenFood가 7되면 실행
            {
                gameSpeedUP++; // gameSpeedUP +1
                timeScale *= 0.95f; // timeScale +0.1f
                countSevenFood = 0; // countSevenfood reset
            }
            else // if countSevenFood != 7
            {
                countSevenFood++;
            }
        }
    }
}