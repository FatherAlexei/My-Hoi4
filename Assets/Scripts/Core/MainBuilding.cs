using UnityEngine;
using Abstractions;
using Abstractions.Commands;
using System;
using Random = UnityEngine.Random;

public sealed class MainBuilding : CommandExecuterBase<IProduceUnitCommand>, ISelectables
{
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        private float _health = 1000;
        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab, new Vector3(_unitsParent.position.x + Random.Range(-10, 10), 0, _unitsParent.position.z +
            Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }


}