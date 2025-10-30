using UnityEngine;

public class PlayerEvent
{
    public readonly float Timestamp;
    public readonly Command Command;

    public PlayerEvent(float timeStamp, Command command)
    {
        Timestamp = timeStamp;
        Command = command;
    }
}