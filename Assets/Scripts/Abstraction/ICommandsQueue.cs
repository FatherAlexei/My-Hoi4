using Abstractions.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommandsQueue
{
    void EnqueueCommand(object command);
    void Clear();
    ICommand CurrentCommand { get; }

}
