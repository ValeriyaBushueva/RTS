﻿using Abstractions;
using Core.CommandExecutors;
using UnityEngine;
using UserControlSystem.CommandsRealization;

namespace Core
{
    public class MainUnit : MonoBehaviour, ISelectable, IAttackable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;

        public Transform PivotPoint => _pivotPoint;

        public Sprite Icon => _icon;
        public int Damage => _damage;

        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommand;
        [SerializeField] private int _damage = 25;
        
        private float _health = 100;
        private static readonly int PlayDead= Animator.StringToHash("PlayDead");


        public void RecieveDamage(int amount)
        {
            if (_health <= 0)
            {
                return;
            }
            _health -= amount;
            if (_health <= 0)
            {
                _animator.SetTrigger("PlayDead");
                Invoke(nameof(destroy), 1f);
            }
        }
        
        private async void destroy()
        {
            await _stopCommand.ExecuteSpecificCommand(new StopCommand());
            Destroy(gameObject);
        }

    }
}