using Unity.VisualScripting;
using UnityEngine;


public class Generator : MonoBehaviour
{
    [SerializeField]
    public GameObject[] mainFood; // �ֿ� ���� ������ �迭
    [SerializeField]
    public GameObject[] subFood; // ���� ���� ������ �迭

    private GameObject spawn; // ������ ��Ḧ ����
    private GameObject NPC; //  NPC �Ծ� ������Ʈ 
    AudioDirector audioDirector;
    AudioSource audioSource;

   


    private float[][] spanArray = new float[][] // ��� ���� �ֱ⸦ �����ϴ� 2���� �迭
    {
        new float[] {1.0f, 0.9f, 0.9f, 1.0f},
        new float[] {1.0f, 0.8f, 0.8f, 1.0f,},
        new float[] {0.8f, 0.9f, 0.9f, 0.8f, 1.0f},
        new float[] {0.85f, 0.95f, 1.0f, 0.8f},
        new float[] {1.0f, 0.85f, 0.8f, 0.9f},
        new float[] {0.95f, 0.8f, 0.85f, 0.9f}
    };
    float timeScale = 1.0f;//�ð� ����
    private float timeElapsed = 0f; //����� �ð�
    private int rowIndex = 0; // spanArray�� �� �ε���
    private int colIndex = 0; // spanArray�� �� �ε���
    private int gameSpeedUP = 0; // Spanspeed Index
    private int countSevenFood = 0; // ������ 7ȸ ���� �� Ƚ��

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
        timeElapsed += Time.deltaTime; // ����� �ð� ������Ʈ

        if (timeElapsed >= GetCurrentSpan() * timeScale && GameDirector.hp > 0) //���� �ð����� ���Ļ���, hp�� 0���� ū ��쿡�� ����
        {

            NPC.GetComponent<NPCController>().Drawing(); // NPC�� ���� ������ ���ϸ��̼� ����
            SpawnFood(); // ���Ļ���
            Gamespeed(); // ���� �ӵ� ����
            timeElapsed = 0; // Ÿ�̸� �ʱ�ȭ
            if (colIndex == spanArray[rowIndex].Length - 1) // ���� ���� ���������� ������ ���
            {
                UpdateIndices(); // ���� ������ ���� �ε��� ������Ʈ
            }
            else
            {
                colIndex++; // �������� �̵�
            }
        }
        if (GameDirector.hp <= 0)
        {
            audioDirector.SoundMute(true);
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

    private float GetCurrentSpan() // ���� ���� �����ֱ� 
    {
        return spanArray[rowIndex][colIndex]; // * speedArray[];
    }

    private void UpdateIndices()
    {
        rowIndex = Random.Range(0, spanArray.Length); // ���� �ε��� ������Ʈ
        colIndex = 0;
    }

    private void Gamespeed()
    {
        if (gameSpeedUP < 9) // 9���� ���� ��� ����
        {
            if (countSevenFood == 7) //countSevenFood�� 7�Ǹ� ����
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