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
        Vector3 delPosition = Vector3.zero;

        if (Generator.spawn != null && Generator.randomIndex != 2)
        {

            delPosition = Generator.spawn.transform.position;
            Destroy(Generator.spawn);

            LeftHalf(delPosition, Generator.randomIndex);
            RightHalf(delPosition, Generator.randomIndex);

        }
        else if (Generator.spawn != null && Generator.randomIndex == 2 && PlayerController.AtackCount == 2)
        {

            delPosition = Generator.spawn.transform.position;
            Destroy(Generator.spawn);

            LeftHalf(delPosition, Generator.randomIndex);
            RightHalf(delPosition, Generator.randomIndex);
        }

    }

    public static void LeftHalf(Vector3 delPosition, int iRandom)
    {
        leftHalf = Instantiate(half, delPosition, Quaternion.identity);

        SpriteRenderer spriteRendererInstance = leftHalf.AddComponent<SpriteRenderer>();
        spriteRendererInstance.sprite = sprite[iRandom * 2];
        Rigidbody2D rb = leftHalf.GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            rb = leftHalf.AddComponent<Rigidbody2D>();
            rb.gravityScale = 1f;

        }
    }

    public static void RightHalf(Vector3 delPosition, int iRandom)
    {

        delPosition += new Vector3(1f, -0.3f, 0f);
        rightHalf = Instantiate(half, delPosition, Quaternion.identity);
        SpriteRenderer spriteRendererInstance = rightHalf.AddComponent<SpriteRenderer>();
        spriteRendererInstance.sprite = sprite[iRandom * 2 + 1];
        Rigidbody2D rb = rightHalf.GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            rb = rightHalf.AddComponent<Rigidbody2D>();
            rb.gravityScale = 1f;

        }
    }

}
