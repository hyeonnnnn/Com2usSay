using UnityEngine;

public class PlayerEvent
{
    // ����ڰ� �Է��� Ŀ�ǵ带 �����ϱ� ����
    // �ð� + Ŀ�ǵ带 ��Ƶд�.
    public readonly float Timestamp;
    public readonly Command Command;

    public PlayerEvent(float timeStamp, Command command)
    {
        Timestamp = timeStamp;
        Command = command;
    }
}