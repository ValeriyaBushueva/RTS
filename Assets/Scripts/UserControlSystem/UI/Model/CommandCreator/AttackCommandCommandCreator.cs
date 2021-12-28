using System;
using System.Threading;
using System.Threading.Tasks;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem;
using Utils;
using Zenject;

public class AttackCommandCommandCreator :CancellableCommandCreatorBase<IAttackCommand, IAttackable>

{
    protected override IAttackCommand createCommand(IAttackable argument) => new AttackCommand(argument);


    protected override void classSpecificCommanCreator(Action<IAttackCommand> creationCallback)
    {
       
    }
}
