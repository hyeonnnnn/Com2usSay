using UnityEngine;

public class MoveRightCommand : Command
{
    private Player _player;

    public MoveRightCommand(Player player)
    {
        _player = player;
    }

    public override void Execute()
    {
        _player.MoveRight();
    }
}