using System.Threading.Tasks;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
{ 
    public override async Task ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"{name} is attacking{command.Target}!");
    }
}
