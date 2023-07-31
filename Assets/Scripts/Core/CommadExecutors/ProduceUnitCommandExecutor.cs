using Abstractions.Commands;
using log4net.Util;
using UniRx;
using UnityEngine;
using Zenject.Asteroids;
using Random = UnityEngine.Random;
public class ProduceUnitCommandExecutor :
ICommandExecuter<IProduceUnitCommand>, IUnitProducer
{
    public IReadOnlyReactiveCollection<IUnitProductionTask> Queue =>
    _queue;
    [SerializeField] private Transform _unitsParent;
    [SerializeField] private int _maximumUnitsInQueue = 6;
    private ReactiveCollection<IUnitProductionTask> _queue = new
    ReactiveCollection<IUnitProductionTask>();
    private void Update()
    {
        if (_queue.Count == 0)
        {
            return;
        }
        var innerTask = (UnitProductionTask)_queue[0];
        innerTask.TimeLeft -= Time.deltaTime;
        if (innerTask.TimeLeft <= 0)
        {
            removeTaskAtIndex(0);
            var instance = _diContainer.InstantiatePrefab(innerTask.UnitPrefab, transform.position,
            Quaternion.identity, _unitsParent);
            var queue = instance.GetComponent<ICommandsQueue>();
            var mainBuilding = GetComponent<MainBuilding>();
            queue.EnqueueCommand(new MoveCommand(mainBuilding.RallyPoint));


        }
    }
    public void Cancel(int index) => removeTaskAtIndex(index);
    private void removeTaskAtIndex(int index)
    {
        for (int i = index; i < _queue.Count - 1; i++)
{
            _queue[i] = _queue[i + 1];
        }
        _queue.RemoveAt(_queue.Count - 1);
    }
    public override void ExecuteSpecificCommand(IProduceUnitCommand
    command)
    {
        var factionMember = instance.GetComponent<FactionMember>();
        factionMember.SetFaction(GetComponent<FactionMember>().FactionId);
    }
}
