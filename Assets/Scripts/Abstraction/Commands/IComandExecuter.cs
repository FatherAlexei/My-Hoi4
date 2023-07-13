namespace Abstractions.Commands
{
    public interface ICommandExecuter
    {
        void ExecuteCommand(object command);
            
    }
}