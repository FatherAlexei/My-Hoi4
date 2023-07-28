using Abstractions.Commands;
using UnityEngine;
public class PatrolCommandExecutor : ICommandExecuter<IPatrolCommand>
{

    public override void ExecuteCommand(IPatrolCommand command)
    {
        Debug.Log($"name patroling!");
    }
}
