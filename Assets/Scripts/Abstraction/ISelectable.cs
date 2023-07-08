using System.Collections;
using UnityEngine;

namespace Abstractions
{
    public interface ISelectables : IEnumerable
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }
    }
}