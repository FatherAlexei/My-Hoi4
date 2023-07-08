using Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order =0)]
    public class SelectableValue : ScriptableObject
    {
        public ISelectables CurrentValue { get; private set; }

        public  Action<ISelectables> OnSelected;

        public void SetValue(ISelectables value)
        {
            CurrentValue = value;
            OnSelected?.Invoke(value);
        }
    }
}