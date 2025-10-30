using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Invoker : MonoBehaviour
{
    [SerializeField] private Transform _target;

    public bool IsRecording { get; private set; }
    public bool IsReplaying { get; private set; }

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private float _recordStartTime;
    private Coroutine _replayRoutine;
    private readonly List<PlayerEvent> _events = new();

    public void Init(Transform target) => _target = target;

    public void StartNewSegmentRecording()
    {
        if (IsReplaying) StopReplay();

        _events.Clear();
        IsRecording = true;
    }

    public void PushEvent(Command command)
    {
        if (command == null) return;

        command.Execute();

        if (!IsRecording) return;

        if (_events.Count == 0)
        {
            _startPosition = _target.position;
            _startRotation = _target.rotation;
            _recordStartTime = Time.unscaledTime;
        }

        float t = Time.unscaledTime - _recordStartTime;
        _events.Add(new PlayerEvent(t, command));
    }

    public void StartReplay()
    {
        if (_events.Count == 0)
        {
            return;
        }
        if (_target == null)
        {
            return;
        }

        if (IsReplaying) StopReplay();
        IsRecording = false;

        _target.SetPositionAndRotation(_startPosition, _startRotation);

        IsReplaying = true;
        _replayRoutine = StartCoroutine(ReplayAndResume());
    }

    public void StopReplay()
    {
        if (_replayRoutine != null)
        {
            StopCoroutine(_replayRoutine);
            _replayRoutine = null;
        }
        IsReplaying = false;
    }

    private IEnumerator ReplayAndResume()
    {
        _events[0].Command.Execute();

        for (int i = 1; i < _events.Count; i++)
        {
            float wait = Mathf.Max(0f, _events[i].Timestamp - _events[i - 1].Timestamp);
            if (wait > 0f)
                yield return new WaitForSecondsRealtime(wait);

            _events[i].Command.Execute();
        }

        IsReplaying = false;
        StartNewSegmentRecording();
    }
}