using System.Collections;
using UnityEngine;


public class Effect : MonoBehaviour
{
<<<<<<< HEAD
    public static float growthRate = 0.1f;
    public static float maxScale = 6f;
    private static Effect et;
=======
    public static float growthRate = 0.2f;
    public static float maxScale = 6f;
    private static Effect et;
    static float pushPower = 40.0f;
>>>>>>> 766af1bccbed5d26b5e3ad685556ce731b5139c8

    // https://www.youtube.com/watch?v=lty5EXXkFRQ&t=14s //참고
    private void Awake()
    {
<<<<<<< HEAD

=======
>>>>>>> 766af1bccbed5d26b5e3ad685556ce731b5139c8
        et = this;
    }

    public static void Apply(GameObject target)
    {
        et.StartCoroutine(ScaleTarget(target));
    }

    public static IEnumerator ScaleTarget(GameObject target)
    {
<<<<<<< HEAD
        target.transform.position = new Vector3(4f, 2.6f, 0f);
        target.GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(0.1f);


        Destroy(target);

=======
        float currentScale = 3.5f;
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

        if (currentScale >= 3.5)
        {
            Destroy(target);
        }
>>>>>>> 766af1bccbed5d26b5e3ad685556ce731b5139c8

    }
}
