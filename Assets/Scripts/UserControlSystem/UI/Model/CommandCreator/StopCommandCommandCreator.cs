using System;
using System.Threading.Tasks;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem;
using Utils;
using Zenject;

public class StopCommandCommandCreator :CommandCreatorBase<IStopCommand>
{
    [Inject] private AssetsContext _context;

    protected override async Task ClassSpecificCommandCreation(Action<IStopCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new StopCommand()));
    }

    protected override void classSpecificCommanCreator(Action<IStopCommand> creationCallback)
    {
        //NONE
    }
}
