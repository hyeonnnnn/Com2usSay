using UnityEngine;
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

public class InputController : MonoBehaviour
{
    [SerializeField] private Player player;

    private Invoker invoker;
    private bool isRecording = true;
    private bool isReplaying = false;
    private Command keycodeLeft, keycodeRight, keycodeSpace;

    private void Start()
    {
        invoker = gameObject.AddComponent<Invoker>();
        keycodeLeft = new MoveLeftCommand(player);
        keycodeRight = new MoveRightCommand(player);
        keycodeSpace = new JumpCommand(player);
    }

    private void Update()
    {
        // 키 입력을 인보터에게 커맨드 전달
        if(isReplaying == false && isRecording == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                invoker.ExecuteCommand(keycodeLeft);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                invoker.ExecuteCommand(keycodeRight);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                invoker.ExecuteCommand(keycodeSpace);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartReplaying();
        }
    }

    public void StartRecording()
    {
        isRecording = true;
        isReplaying = false;

        invoker.Record();
    }

    public void StartReplaying()
    {
        isRecording = false;
        isReplaying = true;

        player.ResetPosition();
        invoker.Replay();
    }
}
