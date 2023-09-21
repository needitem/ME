using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoAtkRange : MonoBehaviour
{
    public int Destination;
    [SerializeField] Transform[] movePos;
    [SerializeField] float speed;
    int moveNum = 0;
    public bool one = true;
    public static bool availableMove = false;
    private GameObject NPC; //  NPC 게임 오브젝트 
    Animator itemAnimator;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        itemAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        NPC = GameObject.Find("NPC");

        availableMove = false;
        //GameDirector.isTouch = true;
        transform.position = movePos[moveNum].transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (availableMove)
        {
            if (one)
            {
                NPC.GetComponent<NPCController>().Drawing(); // NPC가 음식 던지는 에니매이션 실행
                one = false;
            }

            MovePath();

        }
    }

    public void MovePath()
    {
        if (moveNum < movePos.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, movePos[moveNum].transform.position, speed * Time.deltaTime);

            if (transform.position == movePos[moveNum].transform.position)
            {
                moveNum++;
            }

            if (moveNum == movePos.Length)
            {
                Destination = 1;
                //GameDirector.isTouch = false;

            }
        }
    }

    public void BtnClick()
    {
        if(Destination == 1)
        {
            itemAnimator.SetTrigger("slice");
            rb.gravityScale = 1.0f;

            if (gameObject.transform.position.y <= 0.7f)
            // 재료가 맵 아래로 떨어지면 삭제 시키기
            {
                Destroy(gameObject);
            }
            
        }
    }
}



