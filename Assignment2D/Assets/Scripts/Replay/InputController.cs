using System;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;

public class InputController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Invoker _invoker;

    private Command _keycodeLeft;
    private Command _keycodeRight;
    private Command _keycodeSpace;

    private void Start()
    {
        _keycodeLeft = new MoveLeftCommand(_player);
        _keycodeRight = new MoveRightCommand(_player);
        _keycodeSpace = new JumpCommand(_player);
    }

    private void Update()
    {
        if (_invoker.IsReplaying == false)
        {
            // 입력할 때마다 커맨드 넣기
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
    }
}
