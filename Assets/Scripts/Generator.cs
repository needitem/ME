using Unity.VisualScripting;
using UnityEngine;


public class Generator : MonoBehaviour
{
    public GameObject[] mainFood;
    public GameObject[] subFood;
    private GameObject spawn;
    private GameObject NPC;
    AudioDirector audioDirector;
    AudioSource audioSource;


    private float[][] spanArray = new float[][]
    {
        new float[] {1.0f, 0.9f, 0.9f, 1.0f},
        new float[] {1.0f, 0.8f, 0.8f, 1.0f,},
        new float[] {0.8f, 0.9f, 0.9f, 0.8f, 1.0f},
        new float[] {0.85f, 0.95f, 1.0f, 0.8f},
        new float[] {1.0f, 0.85f, 0.8f, 0.9f},
        new float[] {0.95f, 0.8f, 0.85f, 0.9f}
    };

    private float[] SpanSpeed = new float[] { 1.0f, 0.95f, 0.9f, 0.85f, 0.8f, 0.75f, 0.7f, 0.65f, 0.6f, 0.55f }; // gamespeed control
    private float timeElapsed = 0f;
    private int rowIndex = 0; // spanArray row
    private int colIndex = 0; // spanArray col
    private int SpeedIndex = 0; // Spanspeed Index

    private int Index = 0;
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
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= GetCurrentSpan() && GameDirector.hp > 0) // generate food every span seconds
        {
            NPC.GetComponent<NPCController>().Drawing(); // NPC throw food animation
            SpawnFood();
            timeElapsed = 0; // reset timer
            Speedincrease();
            if (colIndex == spanArray[rowIndex].Length - 1)
            {
                UpdateIndices(); // update indices for next spawn
            }
            else
            {
                colIndex++;
            }
        }

        if (GameDirector.hp <= 0)
        {
            audioDirector.SoundMute(true);
        }
    }

    public void SpawnFood() // spawn food
    {
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);
        GameObject foodPrefab;
        int itemHp;

        if (Random.Range(0, 3) == 0) // 1/3 chance to spawn main food. set bigger value to increase chance
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
        spawn.name = foodPrefab.name; // set name of food to its prefab name. prevent (prefab) in hierarchy
        spawn.GetComponent<ItemController>().itemHp = itemHp;
    }

    private float GetCurrentSpan() // get current span
    {
        return spanArray[rowIndex][colIndex] *SpanSpeed[SpeedIndex]; // speedArray[];
    }

    private void UpdateIndices()
    {
        rowIndex = Random.Range(0, spanArray.Length); // update row index
        colIndex = 0;
    }

    private void Speedincrease()
    {
        if (SpeedIndex >= 9) // SpeedIndex가 9 이상인 경우 추가 연산을 수행하지 않음
        {
            return;
        }

        if (Index == 7) // Index가 7인지 확인
        {
            SpeedIndex++;
            Index = 0;
        }
        else
        {
            Index++;
        }

    }
}