using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Effect : MonoBehaviour
{

    public float growthRate = 0.2f;
    public float maxScale = 6f;

    public void PunchBack(Object target)
    {
        Debug.Log(target);
        Invoke(nameof(ScaleTarget), 0.0f);
    }

    private void ScaleTarget()
    {
        float currentScale = 1f;
    }

    public static void Destroyfruits(GameObject gameObject)
    {
        //Play Animation here
        Destroy(gameObject);

    }

    
}
