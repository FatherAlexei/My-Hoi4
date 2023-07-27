using Abstractions;
using System;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order =0)]
    public class SelectableValue : StatefulScriptableObjectValueBase<ISelectables>
    {
        public  Action<ISelectables> OnSelected;

    }
}