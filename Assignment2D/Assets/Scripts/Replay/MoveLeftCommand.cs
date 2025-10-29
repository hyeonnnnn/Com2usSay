using UnityEngine;

public class MoveLeftCommand : Command
{
    public override void Execute(GameActor actor)
    {
        actor.MoveLeft();
    }
}