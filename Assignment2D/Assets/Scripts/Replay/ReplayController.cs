// GhostReplayController.cs
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReplayController : MonoBehaviour
{
    private List<PlayerEvent> _events;
    private GameActor _ghost;

    public void InitController(GameActor ghost, List<PlayerEvent> events)
    {
        _ghost = ghost;
        _events = new List<PlayerEvent>(events);
    }

    public IEnumerator ExecuteReplay()
    {
        if (_events == null || _events.Count == 0)
            yield break;

        float startTime = Time.time;
        int index = 0;

        while (index < _events.Count)
        {
            float elapsed = Time.time - startTime;

            if (_events[index].Timestamp <= _events[0].Timestamp + elapsed)
            {
                _events[index].Command.Execute(_ghost);
                index++;
            }

            yield return null;
        }
    }
}