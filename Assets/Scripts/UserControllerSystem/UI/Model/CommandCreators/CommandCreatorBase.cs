using Abstractions.Commands;
using System;
public abstract class CommandCreatorBase<T> where T : ICommand
{
    public ICommandExecuter ProcessCommandExecutor(ICommandExecuter commandExecutor, Action<T> callback)
    {
        var classSpecificExecutor = commandExecutor as CommandExecuterBase<T>;
        if (classSpecificExecutor != null)
        {
            classSpecificCommandCreation(callback);
        }
        return commandExecutor;
    }
    protected abstract void classSpecificCommandCreation(Action<T> creationCallback);
    public virtual void ProcessCancel() { }
}