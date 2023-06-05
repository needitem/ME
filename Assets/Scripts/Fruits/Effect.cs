using UnityEngine;

public class Effect : MonoBehaviour
{
    
    public static GameObject leftHalf;
    public static GameObject rightHalf;
    static Sprite[] sprite = Resources.LoadAll<Sprite>("SlicePrefabs");
    public static GameObject half = new GameObject("halfPrefab");

    public static void PunchBack(Collider2D target)
    {

        float pushPower = 5.0f;
        float fUpSize = 0.2f;

        target.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * pushPower, ForceMode2D.Impulse);

        while (fUpSize <= 6)
        {

            target.transform.localScale = new Vector3(fUpSize, fUpSize, 0);
            fUpSize += 0.1f;

        }

    }


    public static void Destroyfruits()
    {
        

    }

    

}
