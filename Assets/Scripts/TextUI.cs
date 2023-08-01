using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUI : MonoBehaviour
{ 
    public float movespeed;
    public float alphaSpeed;
    public float destroyTime;
    TextMeshPro text;
    Color alpha;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>(); // TextMeshPro 컴포넌트 가져오기
        alpha = text.color;                 // 현재 텍스트 색상 값 가져오기
    }

    // Update is called once per frame
    void Update()
    {
        // 텍스트 오브젝트를 위로 이동시키는 기능
        transform.Translate(new Vector3(0, movespeed * Time.deltaTime, 0));
        // alpha 값의 투명도를 시간에 따라 0으로 보간하여 감소시킴
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        // 보간된 alpha 값으로 텍스트 색상 업데이트
        text.color = alpha;
        // 일정 시간 이후에 스코어 오브젝트 제거
        Invoke("DestroyScore", destroyTime);
    }
    private void DestroyScore()
    {
        // 스코어 오브젝트 제거
        Destroy(gameObject);
    }
}
