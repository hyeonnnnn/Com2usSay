using UnityEngine;

public abstract class GameActor : MonoBehaviour
{
    public abstract void MoveLeft();
    public abstract void MoveRight();
    public abstract void Jump();
}
