using Abstractions.Commands;
using System.Threading;
using UnityEngine;
public class StopCommandExecutor : CommandExecuterBase<IStopCommand>
{
    public CancellationTokenSource CancellationTokenSource { get; set; }
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        CancellationTokenSource?.Cancel();
    }
}
