using UnityEngine;

public class Player : GameActor
{
    public float speed = 5f;
    public Rigidbody2D rb;
    private Vector2 velocity;

    public float firstXPosition;
    public float firstYPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public Vector2 GetStartPosition()
    {
        return new Vector2(firstXPosition, firstYPosition);
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
        rb.AddForce(Vector2.up * 300f);
    }
}
