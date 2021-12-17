using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;

public class StopCommand : IStopCommand
{
    public GameObject UnitPrefab => _unitPrefab;
    [InjectAsset("Chomper")] private GameObject _unitPrefab;
}
