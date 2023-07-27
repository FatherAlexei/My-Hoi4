using System.Collections;
using UnityEngine;

namespace Abstractions
{
    public interface ISelectables : IHealthHolder
    {
        Transform PivotPoint { get; }
        Sprite Icon { get; }

    }
}