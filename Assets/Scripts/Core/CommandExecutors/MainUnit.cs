using System.Collections;
using System.Collections.Generic;
using Abstractions;
using UnityEngine;

public class MainUnit : MonoBehaviour, ISelectable, IAttackable
{
    public float Health => _health; 
    public float MaxHealth => _maxHealth;
    public Transform PivotPoint => transform;
    
    public Sprite Icon => _icon;
    
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotTransform;

    private float _health = 100;
}
