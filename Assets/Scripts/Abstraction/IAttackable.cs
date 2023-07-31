using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable : IHealthHolder
{
    void RecieveDamage(int amount);

}
