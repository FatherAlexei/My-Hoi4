using UnityEngine;
using Abstractions.Commands;
using System.Threading.Tasks;

public class AttackCommandExecutor : ICommandExecuter<IAttackCommand>
{
    public override async Task ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"name is attacking!");
    }

}