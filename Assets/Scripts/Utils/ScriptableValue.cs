using System;
using UnityEngine;

public abstract class ScriptableValue<T> : ScriptableObject, IAwaitable<T>
{
    public class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
    {
        private readonly ScriptableValue<TAwaited>
        _scriptableObjectValueBase;
        public NewValueNotifier(ScriptableValue<TAwaited>
        scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += onNewValue;
        }
        private void onNewValue(TAwaited obj)
        {
            _scriptableObjectValueBase.OnNewValue -= onNewValue;
            onWaitFinish(obj);
        }
    }


    public T CurrentValue { get; private set; }
    public Action<T> OnNewValue;
    public void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }
    public IAwaiter<T> GetAwaiter()
    {
        return new NewValueNotifier<T>(this);
    }
}
