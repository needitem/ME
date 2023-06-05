using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Effect : MonoBehaviour
{

    public float growthRate = 0.2f;
    public float maxScale = 6f;

    public void PunchBack(Collider2D target)
    {

        StartCoroutine(ScaleTarget(target));

    }


    public static void Destroyfruits(GameObject gameObject)
    {
        //Play Animation here
        //Destroy(gameObject);

    }


    public IEnumerator ScaleTarget(Collider2D target)
    {
        float currentScale = 1f;

        while (currentScale <= maxScale)
        {
            transform.localScale = new Vector3(currentScale, currentScale, 1f);
            currentScale += growthRate;
            yield return null; // Wait for one frame
        }

        // Scaling completed
        Debug.Log("Scaling completed!");
    }
    
}
