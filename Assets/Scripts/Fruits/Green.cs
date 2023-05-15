using UnityEngine;

public class Green : MonoBehaviour {
    [SerializeField] private float pushPower = 5.0f;
    [SerializeField] private float upPower = 15.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    void FixedUpdate()
    {
        // add gravity to the rigidbody
        rb.AddForce(new Vector2(0, Physics2D.gravity.y * rb.mass));

        // add the push force
        Vector2 pushForce = transform.right * pushPower;
        rb.AddForce(pushForce);

        // add the up force
        Vector2 upForce = transform.up * upPower;
        rb.AddForce(upForce);
    }

    void Launch()
    {
        // calculate the initial velocity needed for a parabolic path
        float launchAngle = 45f; // adjust this to change the angle of the parabola
        float launchSpeed = Mathf.Sqrt((upPower * upPower) / (2 * Mathf.Sin(launchAngle * Mathf.Deg2Rad)));
        Vector2 launchVelocity = new Vector2(transform.right.x * launchSpeed, transform.up.y * launchSpeed);

        // apply the initial velocity to the rigidbody
        rb.velocity = launchVelocity;
    }
}