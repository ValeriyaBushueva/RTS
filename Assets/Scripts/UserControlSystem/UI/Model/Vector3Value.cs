using System;
using System.Threading.Tasks;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Strategy Game/" + nameof(Vector3Value), order = 0)]
    public sealed class Vector3Value : ScriptableObject, IAwaitable<Vector3>
    { 
        public Vector3 CurrentValue { get; private set; }
        public Action<Vector3> OnNewValue;
        
        public void SetValue(Vector3 value)
        {
            CurrentValue = value;
            OnNewValue?.Invoke(value);
        }

        public IAwaiter<Vector3> GetAwaiter()
        {
            return null; //NONE
        }
    }
}