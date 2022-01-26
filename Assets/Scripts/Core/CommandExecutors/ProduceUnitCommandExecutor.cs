using System.Threading.Tasks;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UniRx;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using Random = UnityEngine.Random;
using Zenject;

namespace Core.CommandExecutors
{
    public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
    {
        public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

        [SerializeField] private Transform _unitsParent;
        [SerializeField] private int _maximumUnitsInQueue = 6;

        private ReactiveCollection<IUnitProductionTask> _queue = new ReactiveCollection<IUnitProductionTask>();
        [Inject] private DiContainer _diContainer;

        private void Update()
        {
            if (_queue.Count == 0)
            {
                return;
            }

            var innerTask = (UnitProductionTask)_queue[0];
            innerTask.TimeLeft -= Time.deltaTime;
            if (innerTask.TimeLeft <= 0)
            {
                removeTaskAtIndex(0);
                
                var instance = _diContainer.InstantiatePrefab(innerTask.UnitPrefab, transform.position, Quaternion.identity, _unitsParent);
              // var queue = instance.GetComponent<ICommandsQueue>();
              // var mainBuilding = GetComponent<MainBuilding>();
              // queue.EnqueueCommand(new MoveCommand(mainBuilding.RallyPoint));
              
              var factionMember = instance.GetComponent<FactionMember>();
              factionMember.SetFaction(GetComponent<FactionMember>().FactionId);

            }
        }

        public void Cancel(int index) => removeTaskAtIndex(index);

        private void removeTaskAtIndex(int index)
        {
            for (int i = index; i < _queue.Count - 1; i++)
            {
                _queue[i] = _queue[i + 1];
            }
            _queue.RemoveAt(_queue.Count - 1);
        }

        public override async  Task ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            _queue.Add(new UnitProductionTask(command.ProductionTime, command.Icon, command.UnitPrefab, command.UnitName));
        }
    }
}