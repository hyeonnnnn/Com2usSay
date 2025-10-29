using UnityEngine;
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

public class InputHandler : MonoBehaviour
{
    public event Action<Command> OnCommand;

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            OnCommand?.Invoke(new MoveLeftCommand());
        }

        if (Input.GetKey(KeyCode.D))
        {
            OnCommand?.Invoke(new MoveRightCommand());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnCommand?.Invoke(new JumpCommand());
        }
    }
}
