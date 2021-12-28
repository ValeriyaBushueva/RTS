using System.Threading.Tasks;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Abstractions.Commands.CommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;


        public override async Task ExecuteSpecificCommand(IMoveCommand command)
        {
            GetComponent<NavMeshAgent>().destination = command.Target;
            _animator.SetTrigger("Walk");
            await _stop;
            _animator.SetTrigger("Idle");

        }
    }
}