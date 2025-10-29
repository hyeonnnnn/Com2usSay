using UnityEngine;

public class JumpCommand : Command
{
    public override void Execute(GameActor actor)
    {
        actor.Jump();
    }
}