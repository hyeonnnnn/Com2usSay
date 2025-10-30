using UnityEngine;

public class Player : GameActor
{
    public float speed = 5f;
    public Rigidbody2D rb;
    private Vector2 velocity;
    private float jumpForce = 500f;

    public Vector3 initialPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        initialPosition = transform.position;
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
