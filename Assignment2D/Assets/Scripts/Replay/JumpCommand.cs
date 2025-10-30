using UnityEngine;

public class JumpCommand : Command
{
    private Player _player;

    public JumpCommand(Player player)
    {
        _player = player;
    }

    public override void Execute()
    {
        _player.Jump();
    }
}