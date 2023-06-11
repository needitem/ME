using System.Collections;
using UnityEngine;


public class Effect : MonoBehaviour
{
    public static float growthRate = 0.1f;
    public static float maxScale = 6f;
    private static Effect et;

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
        target.transform.position = new Vector3(4f, 2.6f, 0f);
        target.GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(0.1f);


        Destroy(target);


    }
}
