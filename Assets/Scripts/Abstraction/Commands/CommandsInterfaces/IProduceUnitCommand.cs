using Abstractions.Commands;
using UnityEngine;
public interface IProduceUnitCommand : ICommand
{
    GameObject UnitPrefab { get; }
}
