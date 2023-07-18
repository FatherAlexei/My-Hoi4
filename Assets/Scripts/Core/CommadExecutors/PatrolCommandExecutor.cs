using Abstractions.Commands;
using UnityEngine;
public class PatrolCommandExecutor : CommandExecuterBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log($"{name} patroling!");
    }
}
