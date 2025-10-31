using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Invoker : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _recordedStartTime;
    private Vector3 _startPosition;
    private Coroutine _replayCoroutine;
    // PlayerEvent Ÿ���� ��ü�� ����
    public List<PlayerEvent> _events = new List<PlayerEvent>();

    public bool IsRecording { get; private set; }
    public bool IsReplaying { get; private set; }

    private void Start()
    {
        _startPosition = transform.position;
    }

    public void PushEvent(Command command)
    {
        command.Execute();

        // ���÷��� ���� ����X
        if(IsReplaying == true)
        {
            return;
        }

        // ���÷��̰� ������ Ŀ�ǵ尡 �� ������� �׶��� ��ġ�� �ð� ����
        if (_events.Count == 0) 
        {
            _startPosition = _target.position;
            _recordedStartTime = Time.unscaledTime;
        }

        float elapsedTime = Time.unscaledTime - _recordedStartTime;
        _events.Add(new PlayerEvent(elapsedTime, command));
    }

    public void StartRecording()
    {
        IsRecording = true;
        IsReplaying = false;
        _events.Clear(); // ���ڵ� ������ �� ���� Ŀ�ǵ� �� �����
    }

    public void StartReplay()
    {
        IsReplaying = true;
        IsRecording = false;

        _target.position = _startPosition;
        _replayCoroutine = StartCoroutine(Replay());
    }

    private IEnumerator Replay()
    {

        _events[0].Command.Execute();

        for (int i = 1; i < _events.Count; i++)
        {
            float waitTime = _events[i].Timestamp - _events[i - 1].Timestamp;
            yield return new WaitForSeconds(waitTime);
            _events[i].Command.Execute();
        }

        IsReplaying = false; // ���÷��� ����
    }
}