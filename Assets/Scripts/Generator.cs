using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    public GameObject[] mainFood;
    [SerializeField]
    public GameObject[] subFood;

    private GameObject spawn;
    private GameObject NPC;
   
    private float[][] spanArray = new float[][] // game beat
    {
        new float[] {1.0f, 0.9f, 0.9f, 1.0f},
        new float[] {1.0f, 0.8f, 0.8f, 1.0f,},
        new float[] {0.8f, 0.9f, 0.9f, 0.8f, 1.0f},
        new float[] {0.85f, 0.95f, 1.0f, 0.8f},
        new float[] {1.0f, 0.85f, 0.8f, 0.9f},
        new float[] {0.95f, 0.8f, 0.85f, 0.9f}
    };

    private float timeElapsed = 0f; //
    private int rowIndex = 0; // spanArray row
    private int colIndex = 0; // spanArray col
    private int gameSpeedUP = 0; // Spanspeed Index
    private int countSevenFood= 0; // Where food counts to 7 servings

    void Start()
    {
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

            if (colIndex == spanArray[rowIndex].Length - 1)
            {
                UpdateIndices(); // update indices for next spawn
            }
            else
            {
                colIndex++;
            }
        }
        Gamespeed();
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
        }
        else
        {
            foodPrefab = subFood[Random.Range(0, subFood.Length)];
            itemHp = 1; // sub food has 1 hp

        }

        spawn = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        spawn.name = foodPrefab.name; // set name of food to its prefab name. prevent (prefab) in hierarchy
        spawn.GetComponent<ItemController>().itemHp = itemHp;
    }

    private float GetCurrentSpan() // get current span
    {
        return spanArray[rowIndex][colIndex]; // * speedArray[];
    }

    private void UpdateIndices()
    {
        rowIndex = Random.Range(0, spanArray.Length); // update row index
        colIndex = 0;
    }

    private void Gamespeed()
    {
        if (gameSpeedUP < 9) // If gameSpeedUP is less than 9, no additional operations are performed
        {
            if (countSevenFood == 7) //countSevenFood find 7
            {
                gameSpeedUP++; // gameSpeedUP +1

                for (int i = 0; i < spanArray.Length; i++) // All spanArray * 0.95 
                {
                    for (int j = 0; j < spanArray[i].Length; j++)
                    {
                        spanArray[i][j] *= 0.95f; 
                    }
                }
                countSevenFood = 0; // countSevenfood reset
            }
            else // if countSevenFood != 7
            {
                countSevenFood++;
            }
        }
    }
}
