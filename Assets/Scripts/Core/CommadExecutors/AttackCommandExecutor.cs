using UnityEngine;
using Abstractions.Commands;

public class AttackCommandExecutor : CommandExecuterBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"{name} is attacking!");
    }

}