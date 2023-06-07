using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] mainfood;
    public GameObject[] subfood;
    private GameObject spawn;
    private GameObject NPC;
    private float[][] spanArray = new float[][]
    {
        new float[] {1.0f, 1.0f, 1.0f, 1.0f},
        new float[] {1.0f, 0.5f, 0.5f, 1.0f,1.0f},
        new float[] {0.4f, 0.4f, 0.7f, 0.5f, 1.0f},
        new float[] {0.25f, 0.25f, 0.6f, 0.8f, 0.6f, 1.0f, 0.5f},
        new float[] {0.6f, 0.9f,0.5f, 1.0f}
    };

    private float timeElapsed = 0f;
    private int rowIndex = 0;
    private int colIndex = 0;

    public float span = 1.3f;


    void Start()
    {
        mainfood = Resources.LoadAll<GameObject>("Prefabs/MainFood");
        subfood = Resources.LoadAll<GameObject>("Prefabs/SubFood");
        rowIndex = Random.Range(0, spanArray.Length);
        NPC = GameObject.Find("NPC");
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= GetCurrentSpan() && GameDirector.hp > 0)
        {
            NPC.GetComponent<NPCController>().Drawing();
            SpawnFood();
            timeElapsed = 0;
        }
    }
    public void SpawnFood()
    {
        Vector3 spawnPosition = new Vector3(15, 1.5f, 1);

        GameObject foodPrefab;
        int itemHp;

        if (Random.Range(0, 3) == 0)
        {
            foodPrefab = mainfood[Random.Range(0, mainfood.Length)];
            itemHp = 2;
        }
        else
        {
            foodPrefab = subfood[Random.Range(0, subfood.Length)];
            itemHp = 1;
        }

        spawn = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        spawn.name = foodPrefab.name;
        spawn.GetComponent<ItemController>().itemHp = itemHp;

        timeElapsed = 0f;
        if (colIndex == spanArray[rowIndex].Length - 1)
        {
            UpdateIndices();
        }
        else
        {
            colIndex++;
        }
    }
    private float GetCurrentSpan()
    {
        return spanArray[rowIndex][colIndex];
    }

    private void UpdateIndices()
    {
        rowIndex = Random.Range(0, spanArray.Length);
        colIndex = 0;
    }

}


