using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showRecipe : MonoBehaviour
{
    float time;

    // Start is called before the first frame update
    void Start() 
    {
        resetAnim();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        SpringRecipe(gameObject);
    }

    public void resetAnim()
    {
        time = 0.0f;
    }

    public void SpringRecipe(GameObject gameObject)
    {
        if (time < 0.4f) //특정 위치에서 원점으로 이동
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 130 - 325 * time, 0);
        }
        else if (time < 0.5f) // 튕기고
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, time - 0.4f, 0) * 100;
        }
        else if (time < 0.6f) //다시 제자리로
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0.6f - time, 0) * 100;
        }
        else if (time < 0.7f) //튕기고
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, (time - 0.6f) / 2, 0) * 100;
        }
        else if (time < 0.8f) //다시 제자리
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0.05f - (time - 0.7f) / 2, 0) * 100;
        }
        else
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
    }
}
