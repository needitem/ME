using System.Collections;
using UnityEngine;


public class Effect : MonoBehaviour
{
    public static float growthRate = 0.2f;
    public static float maxScale = 6f;
    private static Effect et;
    static float pushPower = 20.0f;

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
        float currentScale = 1f;
        target.GetComponent<Collider2D>().enabled = false;
        while (currentScale <= maxScale)
        {
            target.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * pushPower, ForceMode2D.Impulse);

            target.transform.localScale = new Vector3(currentScale, currentScale, 1f);
            currentScale += growthRate;
            yield return null; // Wait for one frame
        }
        if (currentScale >= 5)
        {
            Destroy(target);
        }

    }

    public static void Destroyfruits(GameObject gameObject)
    {
        //Play Animation here
        if (gameObject.transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }

}
