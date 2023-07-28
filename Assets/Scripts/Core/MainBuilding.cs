using UnityEngine;
using Abstractions;
using Abstractions.Commands;
using System;
using Random = UnityEngine.Random;

public sealed class MainBuilding : ICommandExecuter<IProduceUnitCommand>, ISelectables
{
    public Vector3 RallyPoint { get; set; }
    public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

          public Transform PivotPoint => _pivot;


        [SerializeField] private Transform _unitsParent;
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
         [SerializeField] private Transform _pivot;
         private float _health = 1000;
        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {

        }


}