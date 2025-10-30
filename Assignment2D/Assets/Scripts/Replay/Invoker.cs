using UnityEngine;
using System.Collections.Generic;

public class Invoker : MonoBehaviour
{
    public bool isRecording = false;
    public bool isReplaying = false;
    public float recordingTime;
    public float replayingTime;

    private Queue<PlayerEvent> recordedCommandQueue = new Queue<PlayerEvent>();

    private void Start()
    {
        Record();
    }

    private void FixedUpdate()
    {
        // ��ȭ�� �� ��ȭ �ð� �ø���
        if (isRecording)
        {
            recordingTime += Time.deltaTime;
        }
        // ����� �� ��� �ð� �ø��� Ŀ�ǵ� �����ϱ�
        else if (isReplaying)
        {
            replayingTime += Time.deltaTime;

            // ���� Ŀ�ǵ� ������ ������ ��� ����
            if(recordedCommandQueue.Count > 0)
            {
                if (Mathf.Approximately(replayingTime, recordedCommandQueue.Peek().Timestamp))
                {
                    recordedCommandQueue.Peek().Command.Execute();
                    recordedCommandQueue.Dequeue();
                }
            }
            // ���� Ŀ�ǵ� ������ ��� �����ϰ� �ٽ� ��ȭ ���
            else
            {
                isReplaying = false;
                Record();
            }
        }
    }

    public void ExecuteCommand(Command command)
    {
        command.Execute();

        if (isRecording)
        {
            recordedCommandQueue.Enqueue(new PlayerEvent(recordingTime, command));
        }
    }

    public void Record()
    {
        if (isReplaying) return;

        recordingTime = 0;
        isRecording = true;
        isReplaying = false;
    }

    public void Replay()
    {
        Debug.Log("Replaying Start");
        recordingTime = 0;
        replayingTime = 0;
        isReplaying = true;
        isRecording = false;

        if (recordedCommandQueue.Count <= 0)
        {
            Debug.LogError("��ȭ�� Ŀ�ǵ尡 ����");
        }
    }

}
