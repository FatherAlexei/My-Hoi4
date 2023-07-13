using Abstractions;
using Abstractions.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : CommandExecuterBase<IAttackCommand>, ISelectables
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Sprite _icon;
    private float _health = 100;
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log("I Attacked");
    }

}
    