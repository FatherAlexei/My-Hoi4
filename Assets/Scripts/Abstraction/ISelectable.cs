using System.Collections;
using UnityEngine;

namespace Abstractions
{
    public interface ISelectables : IHealthHolder, IIconHolder
    {
        Transform PivotPoint { get; }
    }
}