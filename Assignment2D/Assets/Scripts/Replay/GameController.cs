using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class GameController : MonoBehaviour
{
    public InputHandler _inputHandler;
    public Player _player;
    public ReplayController _replayController;

    private List<PlayerEvent> _recordedEvents = new List<PlayerEvent>();
    private bool _isRecording = true;

    private void Start()
    {
        _inputHandler.OnCommand += HandleCommand;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R key is clicked");
            StartReplay();
        }
    }

    private void HandleCommand(Command command)
    {
        command.Execute(_player);

        if (_isRecording)
        {
            _recordedEvents.Add(new PlayerEvent(Time.time, command));
        }
    }

    private void StartReplay()
    {
        // _isRecording = false;
        // StopAllCoroutines();
        _replayController.InitController(_player, _recordedEvents);
        _replayController.InitPlayer(_player, _player.initialPosition, _player.rb);
        // StartCoroutine(_replayController.ExecuteReplay());
    }
}
