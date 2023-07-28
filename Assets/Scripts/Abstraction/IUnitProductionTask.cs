using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitProductionTask : IIconHolder
{
    public string UnitName { get; }
    public float TimeLeft { get; }
    public float ProductionTime { get; }
}
