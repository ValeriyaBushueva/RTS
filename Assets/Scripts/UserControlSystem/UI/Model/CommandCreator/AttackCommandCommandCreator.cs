using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem;
using Utils;
using Zenject;

public class AttackCommandCommandCreator :CommandCreatorBase<IAttackCommand>
{
    [Inject] private AssetsContext _context;

    protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new AttackCommand()));
    }
}
