using Abstractions;
using System;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order =0)]
    public class SelectableValue : ScriptableValue
    {
        public ISelectables CurrentValue { get; private set; }
        public Action<ISelectables> OnNewValue;

        public  Action<ISelectables> OnSelected;

        public void SetValue(ISelectables value)
        {
            CurrentValue = value;
            OnSelected?.Invoke(value);
        }
    }
}