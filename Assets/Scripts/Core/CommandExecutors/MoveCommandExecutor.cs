using System.Threading;
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
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;



        public override async Task ExecuteSpecificCommand(IMoveCommand command)
        {
            GetComponent<NavMeshAgent>().destination = command.Target;
            _animator.SetTrigger("Walk");
            await _stop;
            _animator.SetTrigger("Idle");
            
            
        //     _animator.SetTrigger(Animator.StringToHash(AnimationTypes.Walk));
        //     _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();
        //     try
        //     {
        //         await _stop
        //             .WithCancellation
        //             (
        //                 _stopCommandExecutor
        //                     .CancellationTokenSource
        //                     .Token
        //             );
        //     }
        //     catch
        //     {
        //         GetComponent<NavMeshAgent>().isStopped = true;
        //         GetComponent<NavMeshAgent>().ResetPath();
        //     }
        //     _stopCommandExecutor.CancellationTokenSource = null;
        //     _animator.SetTrigger(Animator.StringToHash(AnimationTypes.Idle));
        // }


          

        }
    }
}