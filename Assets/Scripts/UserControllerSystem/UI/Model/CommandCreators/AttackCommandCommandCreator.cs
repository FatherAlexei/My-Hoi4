using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UserControlSystem;
using Zenject;

public class AttackCommandCommandCreator :
CancellableCommandCreatorBase<IAttackCommand, IAttackable>
{
    protected override IAttackCommand createCommand(IAttackable argument) => new
    AttackCommand(argument);
}

