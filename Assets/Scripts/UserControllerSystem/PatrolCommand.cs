using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCommand : IPatrolCommand
{
    public PatrolCommand(Vector3 position, Vector3 groundClick)
    {
        Position = position;
        GroundClick = groundClick;
    }

    public Vector3 From { get; }

    public Vector3 To { get; }
    public Vector3 Position { get; }
    public Vector3 GroundClick { get; }
}
