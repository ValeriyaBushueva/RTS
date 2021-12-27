using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;
using Zenject;

public  sealed class AttackCommand :IAttackCommand
{
    public IAttackable Target { get; }

    public AttackCommand()
    {
        
    }
    public AttackCommand(IAttackable target)
    {
        Target = target;
    }

    
}
