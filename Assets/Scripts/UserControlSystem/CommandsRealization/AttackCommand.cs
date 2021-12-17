using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;

public  sealed class AttackCommand :IAttackCommand
{
    public GameObject UnitPrefab => _unitPrefab;
    [InjectAsset("Chomper")] private GameObject _unitPrefab;
}
