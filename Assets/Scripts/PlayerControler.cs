using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    [SerializeField] private float curTime;
    public float coolTime = 0.2f;
    public Vector2 boxSize;
    public Transform pos;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(curTime <= 0)
            {
                Collider2D[] colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in colliders)
                {
                    Debug.Log(collider.tag);
                    Destroy(collider.gameObject);
                }

                //animator.SetTrigger("attack");
                curTime = coolTime;
            }
            
            
        }
        curTime -= Time.deltaTime;

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

}
