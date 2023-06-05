using UnityEngine;

public class Effect : MonoBehaviour
{
    public static void PunchBack(Collider2D target)
    {

        float pushPower = 50.0f;
        float fUpSize = 0.2f;

        target.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * pushPower, ForceMode2D.Impulse);

        while (fUpSize <= 6)
        {

            target.transform.localScale = new Vector3(fUpSize, fUpSize, 0);
            fUpSize += 0.001f;

        }

    }


    public static void Destroyfruits(GameObject gameObject)
    {
        //Play Animation here
        //Destroy(gameObject);

    }
    
}
