using UnityEngine;

public class MoveRightCommand : Command
{
    Player player;

    public MoveRightCommand(Player player)
    {
        this.player = player;
    }

    public override void Execute()
    {
        this.player.MoveRight();
    }
}