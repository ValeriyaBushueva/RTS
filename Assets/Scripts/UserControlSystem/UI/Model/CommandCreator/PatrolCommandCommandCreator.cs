using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem;
using Utils;
using Zenject;

public class PatrolCommandCommandCreator :CommandCreatorBase<IPatrolCommand>
{
    [Inject] private AssetsContext _context;

    protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new PatrolCommand()));
    }
}
