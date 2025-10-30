using UnityEngine;

public class PlayerEvent
{
    // 사용자가 입력한 커맨드를 저장하기 위해
    // 시간 + 커맨드를 모아둔다.
    public readonly float Timestamp;
    public readonly Command Command;

    public PlayerEvent(float timeStamp, Command command)
    {
        Timestamp = timeStamp;
        Command = command;
    }
}