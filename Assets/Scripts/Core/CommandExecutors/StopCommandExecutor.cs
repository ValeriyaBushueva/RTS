using System.Threading.Tasks;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
{
    public override async Task ExecuteSpecificCommand(IStopCommand command)
    {
        Debug.Log($"{name} has stopped!");
    }
}
