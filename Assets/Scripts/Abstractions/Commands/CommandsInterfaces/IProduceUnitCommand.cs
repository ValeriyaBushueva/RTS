using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IProduceUnitCommand : ICommand, IIconHolder
    {
        float ProductionTime { get; }
        Sprite Icon { get; }
        GameObject UnitPrefab { get; }
        string UnitName { get; }
    }
}