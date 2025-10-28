using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    public Vector3 MoveDirection { get; set; } = Vector3.zero;


    public void Update()
    {
        transform.position += MoveDirection * moveSpeed * Time.deltaTime;
    }
}
