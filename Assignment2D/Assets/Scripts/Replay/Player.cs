using UnityEngine;

public class Player : GameActor
{
    private Rigidbody2D rb;
    private Vector2 velocity;
    private Vector3 initialPosition;
    private float speed = 5f;
    private float jumpForce = 500f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        initialPosition = transform.position;
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
        rb.linearVelocity = Vector2.zero;
    }

    public override void MoveLeft()
    {
        velocity = new Vector2(-speed, rb.linearVelocity.y);
        rb.linearVelocity = velocity;
    }

    public override void MoveRight()
    {
        velocity = new Vector2(speed, rb.linearVelocity.y);
        rb.linearVelocity = velocity;
    }

    public override void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }
}
