using System;
using UnityEngine;
using Zenject;

namespace UserControlSystem
{
    public class MoveCommandCommandCreator :
    CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        protected override IMoveCommand createCommand(Vector3 argument) => new
        MoveCommand(argument);
    }

}