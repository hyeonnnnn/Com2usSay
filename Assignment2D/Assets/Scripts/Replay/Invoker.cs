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
        // 녹화할 때 녹화 시간 늘리기
        if (isRecording)
        {
            recordingTime += Time.deltaTime;
        }
        // 재생할 때 재생 시간 늘리고 커맨드 실행하기
        else if (isReplaying)
        {
            replayingTime += Time.deltaTime;

            // 남은 커맨드 없어질 때까지 모두 실행
            if(recordedCommandQueue.Count > 0)
            {
                if (Mathf.Approximately(replayingTime, recordedCommandQueue.Peek().Timestamp))
                {
                    recordedCommandQueue.Peek().Command.Execute();
                    recordedCommandQueue.Dequeue();
                }
            }
            // 남은 커맨드 없으면 재생 종료하고 다시 녹화 모드
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
            Debug.LogError("녹화된 커맨드가 없음");
        }
    }

}
