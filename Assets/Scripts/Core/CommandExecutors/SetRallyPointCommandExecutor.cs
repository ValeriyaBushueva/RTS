using System.Threading.Tasks;
using Abstractions;
using UnityEngine;

public class SetRallyPointCommandExecutor :CommandExecutorBase<ISetRallyPointCommand>
{
    public override async Task ExecuteSpecificCommand(ISetRallyPointCommand command)
    {
        GetComponent<MainBuilding>().RallyPoint = command.RallyPoint;
    }

}
