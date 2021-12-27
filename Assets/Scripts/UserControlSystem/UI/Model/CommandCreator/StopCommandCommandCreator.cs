using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem;
using Utils;
using Zenject;

public class StopCommandCommandCreator :CommandCreatorBase<IStopCommand>
{
    [Inject] private AssetsContext _context;

    protected override void ClassSpecificCommandCreation(Action<IStopCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new StopCommand()));
    }
}
