using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReplayController : MonoBehaviour
{
    private List<PlayerEvent> _events;
    private GameActor player;

    public void InitController(GameActor player, List<PlayerEvent> events)
    {
        Debug.Log("InitController");
        this.player = player;
        _events = new List<PlayerEvent>(events);
    }

    public void InitPlayer(GameActor player, Vector3 position, Rigidbody2D rb)
    {
        Debug.Log("InitPlayer");
        player.transform.position = position;
        player.transform.rotation = Quaternion.identity;
        rb.linearVelocity = Vector2.zero;
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
                _events[index].Command.Execute(player);
                index++;
            }

            yield return null;
        }
    }
}