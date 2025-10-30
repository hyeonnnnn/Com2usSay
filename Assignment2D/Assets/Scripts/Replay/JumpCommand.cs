using UnityEngine;

public class JumpCommand : Command
{
    Player player;

    public JumpCommand(Player player)
    {
        this.player = player;
    }

    public override void Execute()
    {
        this.player.Jump();
    }
}