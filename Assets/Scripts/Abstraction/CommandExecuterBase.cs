using Abstractions.Commands;
using System.Threading.Tasks;
using UnityEngine;
public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecuter<T>
where T : class, ICommand
{
    public async Task ExecuteSpecificCommand(object command)
    {
        var specificCommand = command as T;
        if (specificCommand != null)
        {
            await ExecuteCommand(specificCommand);
        }
    }
    public abstract Task ExecuteCommand(T command);

    void ICommandExecuter.ExecuteSpecificCommand(object command)
    {
        throw new System.NotImplementedException();
    }
}