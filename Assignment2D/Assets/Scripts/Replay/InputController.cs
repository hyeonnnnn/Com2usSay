using System;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;

public class InputController : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Invoker _invoker;
    private Command _keycodeLeft;
    private Command _keycodeRight;
    private Command _keycodeSpace;

    private void Start()
    {
        _invoker = gameObject.AddComponent<Invoker>();
        _invoker.Init(_player.transform);

        _keycodeLeft = new MoveLeftCommand(_player);
        _keycodeRight = new MoveRightCommand(_player);
        _keycodeSpace = new JumpCommand(_player);

        _invoker.StartNewSegmentRecording();
    }

    private void Update()
    {
        if (_invoker.IsReplaying == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _invoker.PushEvent(_keycodeLeft);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                _invoker.PushEvent(_keycodeRight);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _invoker.PushEvent(_keycodeSpace);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            _invoker.StartReplay();
        }
    }
}
