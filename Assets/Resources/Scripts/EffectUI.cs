using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EffectUI : MonoBehaviour
{
    [SerializeField] public GameObject textScore_Prefeb;
    [SerializeField] public GameObject ImageRecipe_Prefeb;

    GameObject textObj;
    GameObject imageObj;
    GameObject showRecipe;

    public float movespeed;
    public float alphaSpeed;
    public float destroyTime;
    
    TextMeshProUGUI text;
    Image image;

    Color textAlpha;
    Color ImageAlpha;

    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        textObj = Instantiate(textScore_Prefeb, GameObject.Find("Canvas").transform);
        imageObj = Instantiate(ImageRecipe_Prefeb, GameObject.Find("Canvas").transform);
        showRecipe = GameObject.Find("Canvas/Recipe");

        text = textObj.GetComponent<TextMeshProUGUI>(); // TextMeshPro 컴포넌트 가져오기
        image = imageObj.GetComponent<Image>();

        textAlpha = text.color;                 // 현재 텍스트 색상 값 가져오기
        ImageAlpha = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(time);

        textObj.transform.Translate(new Vector3(0, movespeed * time, 0));
        imageObj.transform.Translate(new Vector3(0, movespeed * time, 0));
        SpringRecipe(showRecipe, time);

        // 텍스트 오브젝트를 위로 이동시키는 기능
        // alpha 값의 투명도를 시간에 따라 0으로 보간하여 감소시킴
        textAlpha.a = Mathf.Lerp(textAlpha.a, 0, time * alphaSpeed);
        ImageAlpha.a = Mathf.Lerp(ImageAlpha.a, 0, time * alphaSpeed);

        // 보간된 alpha 값으로 텍스트 색상 업데이트
        text.color = textAlpha;
        image.color = ImageAlpha;
        
        // 일정 시간 이후에 스코어 오브젝트 제거
        Invoke("DestroyScore", destroyTime);
    }

    private void DestroyScore()
    {
        // 스코어 오브젝트 제거
        Destroy(gameObject);
        Destroy(textObj);
        Destroy(imageObj);
    }

    public void SpringRecipe(GameObject gameObject, float time)
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