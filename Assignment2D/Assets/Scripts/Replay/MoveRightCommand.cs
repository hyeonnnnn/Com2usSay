using UnityEngine;

public class MoveRightCommand : Command
{
    public override void Execute(GameActor actor)
    {
        actor.MoveRight();
    }
}