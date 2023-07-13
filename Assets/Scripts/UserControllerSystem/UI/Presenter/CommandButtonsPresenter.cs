using Abstractions;
using Abstractions.Commands;
using System;
using System.Collections.Generic;
using UnityEngine;
using UserControlSystem;


public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;
    [SerializeField] private AssetsContext _context;
    private ISelectables _currentSelectable;
    private void Start()
    {
        _selectable.OnSelected += onSelected;
        onSelected(_selectable.CurrentValue);
        _view.OnClick += onButtonClick;
    }
    private void onSelected(ISelectables selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;
        _view.Clear();
        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecuter>();
            commandExecutors.AddRange((selectable as
            Component).GetComponentsInParent<ICommandExecuter>());
            _view.MakeLayout(commandExecutors);
        }
    }
    private void onButtonClick(ICommandExecuter commandExecutor)
    {
        var unitProducer = commandExecutor as
        CommandExecuterBase<IProduceUnitCommand>;
        if (unitProducer != null)
        {
            unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommand()));
            return;
        }
        throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}: Unknown type of commands executor: { commandExecutor.GetType().FullName }!");
    }
}
