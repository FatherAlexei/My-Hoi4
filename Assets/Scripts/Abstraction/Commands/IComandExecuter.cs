namespace Abstractions.Commands
{
    public interface ICommandExecuter
    {
        void ExecuteSpecificCommand(object command);
            
    }

    public interface ICommandExecuter<T> : ICommandExecuter where T : ICommand
    {
    }

}