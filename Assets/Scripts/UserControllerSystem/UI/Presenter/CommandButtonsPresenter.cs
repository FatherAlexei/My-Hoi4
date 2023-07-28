using Abstractions;
using Abstractions.Commands;
using System.Collections.Generic;
using UnityEngine;
using UserControlSystem;
using Zenject;
public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;
    [Inject] private CommandButtonsModel _model;
    private ISelectables _currentSelectable;
    private void Start()
    {
        _view.OnClick += _model.OnCommandButtonClicked;
        _model.OnCommandSent += _view.UnblockAllInteractions;
        _model.OnCommandCancel += _view.UnblockAllInteractions;
        _model.OnCommandAccepted += _view.BlockInteractions;
        _selectable.OnNewValue += onSelected;
        onSelected(_selectable.CurrentValue);
    }
    private void onSelected(ISelectables selectable)
    {
        if (_currentSelectable == selectable)
        {
        return;
        }
        if (_currentSelectable != null)
        {
            _model.OnSelectionChanged();
        }
        _currentSelectable = selectable;
        _view.Clear();
        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecuter>();
            commandExecutors.AddRange((selectable as
            Component).GetComponentsInParent<ICommandExecuter>());
            var queue = (selectable as Component).GetComponentInParent<ICommandsQueue>();
            _view.MakeLayout(commandExecutors, queue);

        }
    }
}
