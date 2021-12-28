using System;
using System.Threading.Tasks;
using Abstractions.Commands;

namespace UserControlSystem
{
    public abstract class CommandCreatorBase<TCommand> where TCommand : ICommand
    {
        public ICommandExecutor ProcessCommandExecutor(ICommandExecutor commandExecutor, Action<TCommand> callback)
        {
            var classSpecificExecutor = commandExecutor as CommandExecutorBase<TCommand>;
            if (classSpecificExecutor != null)
            {
                ClassSpecificCommandCreation(callback);
            }
            return commandExecutor;
        }

        protected abstract Task ClassSpecificCommandCreation(Action<TCommand> creationCallback);

        public virtual void ProcessCancel() { }
        protected abstract void classSpecificCommanCreator(Action<TCommand> creationCallback);
    }
}