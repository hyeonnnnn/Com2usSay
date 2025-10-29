using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ActionReplay : MonoBehaviour
{
    private bool isReplayMode = false;
    private int currentReplayIndex;
    private Rigidbody2D rb;
    private List<ActionReplayRecord> actionReplayRecords = new List<ActionReplayRecord>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ChangeReplayMode();
    }

    private void FixedUpdate()
    {
        UpdateReplay();
    }

    private void ChangeReplayMode()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isReplayMode = !isReplayMode;
            if (isReplayMode == true)
            {
                SetTransform(0);
                rb.bodyType = RigidbodyType2D.Kinematic;
            }
            else
            {
                SetTransform(actionReplayRecords.Count - 1);
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    private void UpdateReplay()
    {
        if (isReplayMode == true)
        {
            int nextReplayIndex = currentReplayIndex + 1;

            if (nextReplayIndex < actionReplayRecords.Count)
            {
                SetTransform(nextReplayIndex);
            }
            else
            {
                transform.position = actionReplayRecords[actionReplayRecords.Count - 1].Position;
            }
        }
        else
        {
            actionReplayRecords.Add(new ActionReplayRecord
            {
                Position = transform.position,
                Rotation = transform.rotation
            });
        }
    }

    private void SetTransform(int index)
    {
        currentReplayIndex = index;
        ActionReplayRecord actionReplayRecord = actionReplayRecords[index];

        transform.position = actionReplayRecord.Position;
        transform.rotation = actionReplayRecord.Rotation;
    }
}
