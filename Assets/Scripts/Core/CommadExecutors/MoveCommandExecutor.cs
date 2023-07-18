using Abstractions.Commands;
using UnityEngine;
public class MoveCommandExecutor : CommandExecuterBase<IMoveCommand>
{
    public override void ExecuteSpecificCommand(IMoveCommand command)
    {
        Debug.Log($"{name} is moving to {command.Target}!");
    }
}
