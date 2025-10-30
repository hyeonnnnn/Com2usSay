using UnityEngine;

public class Player : GameActor
{
    private Rigidbody2D _rigidbody;
    private Vector2 _velocity;
    private float _speed = 5f;
    private float _jumpForce = 500f;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void MoveLeft()
    {
        _velocity = new Vector2(-_speed, _rigidbody.linearVelocity.y);
        _rigidbody.linearVelocity = _velocity;
    }

    public override void MoveRight()
    {
        _velocity = new Vector2(_speed, _rigidbody.linearVelocity.y);
        _rigidbody.linearVelocity = _velocity;
    }

    public override void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce);
    }
}
