using Abstractions.Commands;
using System.ComponentModel;
using UnityEngine;
using Zenject;
public class CommandExecutorsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var executors = gameObject.GetComponentsInChildren<ICommandExecuter>();
        foreach (var executor in executors)
        {
            var baseType = executor.GetType().BaseType;
            Container.Bind(baseType).FromInstance(executor);
        }
    }
}
