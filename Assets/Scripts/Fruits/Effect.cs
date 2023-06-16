using System.Collections;
using UnityEngine;


public class Effect : MonoBehaviour
{
    public static float growthRate = 0.2f;
    public static float maxScale = 6f;
    private static Effect et;
    static float pushPower = 40.0f;

    // https://www.youtube.com/watch?v=lty5EXXkFRQ&t=14s //참고
    private void Awake()
    {
        et = this;
    }

    public static void Apply(GameObject target)
    {
        et.StartCoroutine(ScaleTarget(target));
    }

    public static IEnumerator ScaleTarget(GameObject target)
    {
        float currentScale = 4.5f;
        target.GetComponent<Collider2D>().enabled = false;
        //while (currentScale <= maxScale)
        //{
        //target.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        //target.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * pushPower, ForceMode2D.Impulse);
        //target.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * pushPower, ForceMode2D.Impulse);

        Vector2 rightForce = Vector2.right * 250.0f;
        target.GetComponent<Rigidbody2D>().AddForce(rightForce);
        target.GetComponent<Rigidbody2D>().AddForce(rightForce);
        target.GetComponent<Rigidbody2D>().AddForce(rightForce);

        target.transform.localScale = new Vector3(currentScale, currentScale, 1f);
        //currentScale += growthRate;
        //yield return null; // Wait for one frame
        //}

        yield return new WaitForSeconds(0.1f);

        if (currentScale >= 4.5)
        {
            Destroy(target);
        }

    }
}
