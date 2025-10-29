using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    public Vector3 MoveDirection { get; set; } = Vector3.zero;

    private Vector2 moveInput = Vector2.zero;
    private bool isJumping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveDirection = moveInput;
    }

    private void FixedUpdate()
    {
        Move();

        if (isJumping)
        {
            Jump();
            isJumping = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            moveInput = context.ReadValue<Vector2>();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isJumping = true;
        }
    }

    private void Move()
    {
        Vector2 velocity = MoveDirection * moveSpeed;
        rb.linearVelocity = new Vector2(velocity.x, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
