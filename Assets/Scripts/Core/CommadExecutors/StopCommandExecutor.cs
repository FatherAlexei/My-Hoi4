using Abstractions.Commands;
using UnityEngine;
public class StopCommandExecutor : CommandExecuterBase<IStopCommand>
{
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        Debug.Log($"{name} has stopped!");
    }
}