using UnityEngine;

public class MoveLeftCommand : Command
{
    private Player _player;

    public MoveLeftCommand(Player player)
    {
        _player = player;
    }

    public override void Execute()
    {
        _player.MoveLeft();
    }
}