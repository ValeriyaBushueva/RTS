using System;
using System.Threading.Tasks;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

public class MoveCommandCommandCreator : CancellableCommandCreatorBase<IMoveCommand, Vector3>
{
    protected override IMoveCommand createCommand(Vector3 argument) => new MoveCommand(argument);

    protected override void classSpecificCommanCreator(Action<IMoveCommand> creationCallback)
    {
       
    }
}




