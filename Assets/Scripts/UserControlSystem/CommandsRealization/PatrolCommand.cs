using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;

public class PatrolCommand :IPatrolCommand
{
      public GameObject UnitPrefab => _unitPrefab;
     [InjectAsset("Chomper")] private GameObject _unitPrefab;

     public Vector3 From { get; }
     public Vector3 To { get; }

     public PatrolCommand(Vector3 pivotPointPosition, Vector3 groundClick)
     {
         From = pivotPointPosition;
         To = groundClick;
     }
}
