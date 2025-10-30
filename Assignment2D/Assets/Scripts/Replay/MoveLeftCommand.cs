using UnityEngine;

public class MoveLeftCommand : Command
{
    Player player;

    public MoveLeftCommand(Player player)
    {
        this.player = player;
    }

    public override void Execute()
    {
        this.player.MoveLeft();
    }
}