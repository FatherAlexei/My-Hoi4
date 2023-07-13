using Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class CommandButtonsView : MonoBehaviour
{
    public Action<ICommandExecuter> OnClick;
    [SerializeField] public GameObject _attackButton;
    [SerializeField] public GameObject _moveButton;
    [SerializeField] public GameObject _patrolButton;
    [SerializeField] public GameObject _stopButton;
    [SerializeField] public GameObject _produceUnitButton;
    private Dictionary<Type, GameObject> _buttonsByExecutorType;
    private void Start()
    {
        _buttonsByExecutorType = new Dictionary<Type, GameObject>();
        _buttonsByExecutorType
        .Add(typeof(CommandExecuterBase<IAttackCommand>), _attackButton);
        _buttonsByExecutorType
        .Add(typeof(CommandExecuterBase<IMoveCommand>), _moveButton);
        _buttonsByExecutorType
        .Add(typeof(CommandExecuterBase<IPatrolCommand>), _patrolButton);
        _buttonsByExecutorType
        .Add(typeof(CommandExecuterBase<IStopCommand>), _stopButton);
        _buttonsByExecutorType
        .Add(typeof(CommandExecuterBase<IProduceUnitCommand>),
        _produceUnitButton);
    }
    public void MakeLayout(IEnumerable<ICommandExecuter> commandExecutors)
    {
        foreach (var currentExecutor in commandExecutors)
        {
            var buttonGameObject = _buttonsByExecutorType
            .Where(type => type
            .Key
            .IsAssignableFrom(currentExecutor.GetType())
            )
            .First()
            .Value;
            buttonGameObject.SetActive(true);
            var button = buttonGameObject.GetComponent<Button>();
            button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor));
        }
    }
public void Clear()
    {
        foreach (var kvp in _buttonsByExecutorType)
        {
            kvp.Value.GetComponent<Button>().onClick.RemoveAllListeners();
            kvp.Value.SetActive(false);
        }
    }
}
