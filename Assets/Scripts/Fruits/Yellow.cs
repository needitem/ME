using UnityEngine;

public class Yellow : MonoBehaviour
{
    [SerializeField] private float pushPower;
    [SerializeField] public int hp = 2;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        // Move the object to the right
        Vector2 movement = new Vector2(3, 2);
        rb.AddForce(movement * pushPower, ForceMode2D.Impulse);

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }


}